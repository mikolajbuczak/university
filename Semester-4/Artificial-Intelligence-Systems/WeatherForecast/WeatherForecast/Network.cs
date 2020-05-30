using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace WeatherForecast
{
    public class Network
    {
        private static readonly Random Random = new Random();

        public double PoziomNauki { get; set; }
        public double Momentum { get; set; }
        public Layer WarstwaWejsciowa { get; set; }
        public List<Layer> UkrytwaWarstwa { get; set; }
        public Layer WyjsciowaWarstwa { get; set; }


        public Network()
        {
            PoziomNauki = 0;
            Momentum = 0;
            WarstwaWejsciowa = new Layer();
            UkrytwaWarstwa = new List<Layer>();
            WyjsciowaWarstwa = new Layer();
        }

        public Network(int iloscWejsc, int[] iloscUkrytych, int iloscWyjsc, double? poziomNauki = null, double? momentum = null)
        {
            PoziomNauki = poziomNauki ?? .1;
            Momentum = momentum ?? .9;

            WarstwaWejsciowa = new Layer();
            UkrytwaWarstwa = new List<Layer>();
            WyjsciowaWarstwa = new Layer();

            WarstwaWejsciowa = WarstwaWejsciowa.StworzWarstwe(iloscWejsc);

            var pierwszaUkryta = new Layer();
            for (var i = 0; i < iloscUkrytych[0]; i++)
            {
                pierwszaUkryta.Neurony.Add(new Neuron(WarstwaWejsciowa));
            }
            UkrytwaWarstwa.Add(pierwszaUkryta);

            for (int i = 1; i < iloscUkrytych.Length; i++)
            {
                var ukrytaWarstwa = new Layer();
                for (var j = 0; j < iloscUkrytych[i]; j++)
                {
                    ukrytaWarstwa.Neurony.Add(new Neuron(UkrytwaWarstwa[i - 1]));
                }
                UkrytwaWarstwa.Add(ukrytaWarstwa);
            }

            for (var i = 0; i < iloscWyjsc; i++)
            {
                WyjsciowaWarstwa.Neurony.Add(new Neuron(UkrytwaWarstwa.Last()));
            }
        }

        public void Trenuj(List<ZbiorDanych> zbiorDanych, int epochs)
        {
            for (int i = 0; i < epochs; i++)
            {
                foreach (var dane in zbiorDanych)
                {
                    ForwardPropagation(dane.Wartosci);
                    BackPropagation(dane.Cel);
                }
            }
        }

        public void Trenuj(List<ZbiorDanych> zbiorDanych,double minBlad)
        {
            double blad = 1.0;
            int epochs = 0;
            while(blad>minBlad && epochs < int.MaxValue)
            {
                List<double> listaBledow = new List<double>();
                foreach (var dane in zbiorDanych)
                {
                    ForwardPropagation(dane.Wartosci);
                    BackPropagation(dane.Cel);
                    listaBledow.Add(ObliczBlad(dane.Cel));
                }
                blad = listaBledow.Average();
                epochs++;
            }
        }
        private void ForwardPropagation(params double[] wejscie)
        {
            var i = 0;
            for (int j = 0; j < WarstwaWejsciowa.Neurony.Count; j++)
            {
                WarstwaWejsciowa.Neurony[i].Wartosc = wejscie[i++];
            }
            UkrytwaWarstwa.ForEach(x => x.Neurony.ForEach(y => y.ObliczWejscie()));
            WyjsciowaWarstwa.Neurony.ForEach(x => x.ObliczWejscie());
        }

        private void BackPropagation(params double[] cel)
        {
            var i = 0;
            WyjsciowaWarstwa.Neurony.ForEach(x => x.ObliczGradient(cel[i++]));
            UkrytwaWarstwa.Reverse();
            UkrytwaWarstwa.ForEach(x => x.Neurony.ForEach(y => y.ObliczGradient()));
            UkrytwaWarstwa.ForEach(x => x.Neurony.ForEach(y => y.AktualizujWagi(PoziomNauki, Momentum)));
            UkrytwaWarstwa.Reverse();
            WyjsciowaWarstwa.Neurony.ForEach(x => x.AktualizujWagi(PoziomNauki, Momentum));
        }

        public double[] Oblicz(params double[] wejscie)
        {
            ForwardPropagation(wejscie);
            return WyjsciowaWarstwa.Neurony.Select(x => x.Wartosc).ToArray();
        }

        public double ObliczBlad(params double[] cel)
        {
            var i = 0;
            return WyjsciowaWarstwa.Neurony.Sum(x => Math.Abs(x.ObliczBlad(cel[i++])));
        }
        public static double Losuj()
        {
            return 2 * Random.NextDouble() - 1;
        }

        public static Network WczytajWagi(string jsonW1, string jsonW2, string jsonW3, string jsonB1, string jsonB2, string jsonB3)
        {
            double[,] wagiWejsciePierwszaUkryta = JsonConvert.DeserializeObject<double[,]>(File.ReadAllText(jsonW1));
            List<double[,]> wagiUkryte = JsonConvert.DeserializeObject<List<double[,]>>(File.ReadAllText(jsonW2));
            double[,] wagiOstatniaUkrytaWyjscie = JsonConvert.DeserializeObject<double[,]>(File.ReadAllText(jsonW3));

            double[] inputBias = JsonConvert.DeserializeObject<double[]>(File.ReadAllText(jsonB1));
            List<double[]> hiddenBias = JsonConvert.DeserializeObject<List<double[]>>(File.ReadAllText(jsonB2));
            double[] outputBias = JsonConvert.DeserializeObject<double[]>(File.ReadAllText(jsonB3));

            List<int> ukryte = new List<int>();
            foreach (var layer in wagiUkryte)
                ukryte.Add(layer.GetLength(0));

            ukryte.Add(wagiUkryte[wagiUkryte.Count - 1].GetLength(1));

            Network network = new Network(wagiWejsciePierwszaUkryta.GetLength(0), ukryte.ToArray(), wagiOstatniaUkrytaWyjscie.GetLength(1));

            for (int i = 0; i < wagiWejsciePierwszaUkryta.GetLength(0); i++)
                for (int j = 0; j < wagiWejsciePierwszaUkryta.GetLength(1); j++)
                    network.WarstwaWejsciowa.Neurony[i].Wyjscie[j].Waga = wagiWejsciePierwszaUkryta[i, j];

            for (int i = 0; i < wagiUkryte.Count; i++)
            {
                for (int j = 0; j < wagiUkryte[i].GetLength(0); j++)
                    for (int k = 0; k < wagiUkryte[i].GetLength(1); k++)
                        network.UkrytwaWarstwa[i].Neurony[j].Wyjscie[k].Waga = wagiUkryte[i][j, k];
            }

            for (int i = 0; i < wagiOstatniaUkrytaWyjscie.GetLength(0); i++)
                for (int j = 0; j < wagiOstatniaUkrytaWyjscie.GetLength(1); j++)
                    network.UkrytwaWarstwa[network.UkrytwaWarstwa.Count - 1].Neurony[i].Wyjscie[j].Waga = wagiOstatniaUkrytaWyjscie[i, j];

            for (int i = 0; i < inputBias.Length; i++)
                network.WarstwaWejsciowa.Neurony[i].Bias = inputBias[i];

            for (int i = 0; i < hiddenBias.Count; i++)
                for (int j = 0; j < hiddenBias[i].Length; j++)
                    network.UkrytwaWarstwa[i].Neurony[j].Bias = hiddenBias[i][j];

            for (int i = 0; i < outputBias.Length; i++)
                network.WyjsciowaWarstwa.Neurony[i].Bias = outputBias[i];

            return network;
        }

        public void ZapiszWagi()
        {
            double[,] wagiWejsciePierwszaUkryta = new double[WarstwaWejsciowa.Neurony.Count, UkrytwaWarstwa[0].Neurony.Count];
            for (int i = 0; i < WarstwaWejsciowa.Neurony.Count; i++)
                for (int j = 0; j < WarstwaWejsciowa.Neurony[i].Wyjscie.Count; j++)
                    wagiWejsciePierwszaUkryta[i, j] = WarstwaWejsciowa.Neurony[i].Wyjscie[j].Waga;

            List<double[,]> wagiUkryte = new List<double[,]>();

            for (int i = 0; i < UkrytwaWarstwa.Count - 1; i++)
            {
                double[,] wagi = new double[UkrytwaWarstwa[i].Neurony.Count, UkrytwaWarstwa[i + 1].Neurony.Count];
                for (int j = 0; j < UkrytwaWarstwa[i].Neurony.Count; j++)
                    for (int k = 0; k < UkrytwaWarstwa[i + 1].Neurony.Count; k++)
                        wagi[j, k] = UkrytwaWarstwa[i].Neurony[j].Wyjscie[k].Waga;
                wagiUkryte.Add(wagi);
            }

            double[,] wagiOstatniaUkrytaWyjscie = new double[UkrytwaWarstwa[UkrytwaWarstwa.Count - 1].Neurony.Count, WyjsciowaWarstwa.Neurony.Count];
            for (int i = 0; i < UkrytwaWarstwa[UkrytwaWarstwa.Count - 1].Neurony.Count; i++)
                for (int j = 0; j < WyjsciowaWarstwa.Neurony.Count; j++)
                    wagiOstatniaUkrytaWyjscie[i, j] = UkrytwaWarstwa[UkrytwaWarstwa.Count - 1].Neurony[i].Wyjscie[j].Waga;

            double[] biasInput = new double[WarstwaWejsciowa.Neurony.Count];
            for (int i = 0; i < WarstwaWejsciowa.Neurony.Count; i++)
                biasInput[i] = WarstwaWejsciowa.Neurony[i].Bias;

            List<double[]> hiddenbias = new List<double[]>();
            for (int i = 0; i < UkrytwaWarstwa.Count; i++)
            {
                double[] bias = new double[UkrytwaWarstwa[i].Neurony.Count];
                for (int j = 0; j < UkrytwaWarstwa[i].Neurony.Count; j++)
                    bias[j] = UkrytwaWarstwa[i].Neurony[j].Bias;
                hiddenbias.Add(bias);
            }


            double[] biasOutput = new double[WyjsciowaWarstwa.Neurony.Count];
            for (int i = 0; i < WyjsciowaWarstwa.Neurony.Count; i++)
                biasOutput[i] = WyjsciowaWarstwa.Neurony[i].Bias;

            string jsonW1 = JsonConvert.SerializeObject(wagiWejsciePierwszaUkryta);
            string jsonW2 = JsonConvert.SerializeObject(wagiUkryte);
            string jsonW3 = JsonConvert.SerializeObject(wagiOstatniaUkrytaWyjscie);

            string jsonB1 = JsonConvert.SerializeObject(biasInput);
            string jsonB2 = JsonConvert.SerializeObject(hiddenbias);
            string jsonB3 = JsonConvert.SerializeObject(biasOutput);

            File.WriteAllText(@"jsonW1.json", jsonW1);
            File.WriteAllText(@"jsonW2.json", jsonW2);
            File.WriteAllText(@"jsonW3.json", jsonW3);

            File.WriteAllText(@"jsonB1.json", jsonB1);
            File.WriteAllText(@"jsonB2.json", jsonB2);
            File.WriteAllText(@"jsonB3.json", jsonB3);
        }
    }
}
