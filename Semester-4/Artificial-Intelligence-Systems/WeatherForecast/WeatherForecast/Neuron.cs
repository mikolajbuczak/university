using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherForecast
{
    public class Neuron
    {
        public Guid Id { get; set; }
        public List<Synapse> Wejscie { get; set; }
        public List<Synapse> Wyjscie { get; set; }
        public double Bias { get; set; }
        public double BiasDelta { get; set; }
        public double Gradient { get; set; }
        public double Wartosc { get; set; }

        public Neuron()
        {
            Id = Guid.NewGuid();
            Wejscie = new List<Synapse>();
            Wyjscie = new List<Synapse>();
            Bias = Network.Losuj();
        }

        public Neuron(IEnumerable<Neuron> wejscioweNeurony) : this()
        {
            foreach(var x in wejscioweNeurony)
            {
                var synapse = new Synapse(x, this);
                x.Wyjscie.Add(synapse);
                Wejscie.Add(synapse);
            }
        }

        public Neuron(Layer wejscioweNeurony) : this()
        {
            for (int i = 0; i < wejscioweNeurony.Neurony.Count; i++)
            {
                var synapse = new Synapse(wejscioweNeurony.Neurony[i], this);
                wejscioweNeurony.Neurony[i].Wyjscie.Add(synapse);
                Wejscie.Add(synapse);
            }
        }

        public virtual double ObliczWejscie()
        {
            return Wartosc = Sigmoid.Wyjscie(Wejscie.Sum(x => x.Waga * x.WejsciowyNeuron.Wartosc) + Bias);
        }

        public double ObliczBlad(double x)
        {
            return x - Wartosc;
        }

        public double ObliczGradient(double? x = null)
        {
            if (x == null)
            {
                return Gradient = Wyjscie.Sum(y => y.WyjsciowyNeuron.Gradient * y.Waga) * Sigmoid.Pochodna(Wartosc);
            }
            return Gradient = ObliczBlad(x.Value) * Sigmoid.Pochodna(Wartosc);
        }

        public void AktualizujWagi(double poziomNauki,double momentum)
        {
            var poprzedniaDelta = BiasDelta;
            BiasDelta = poziomNauki * Gradient;
            Bias += BiasDelta + momentum * poprzedniaDelta;

            foreach(var x in Wejscie)
            {
                poprzedniaDelta = x.WagaDelta;
                x.WagaDelta = poziomNauki * Gradient * x.WejsciowyNeuron.Wartosc;
                x.Waga += x.WagaDelta + momentum * poprzedniaDelta;
            }
        }

    }
}
