using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WeatherForecast
{
    class Data
    {
        public List<double[]> variablesList = new List<double[]>();

        public List<double[]> trainingInputs = new List<double[]>();
        public List<double[]> trainingTargets = new List<double[]>();

        public List<double[]> testInputs = new List<double[]>();
        public List<double[]> testTargets = new List<double[]>();

        public Data()
        {
            string file = @"Data.csv";
            
            string[] allLines = File.ReadAllLines(file);
            allLines = allLines.Skip(1).ToArray();
            string[][] data = new string[allLines.Length][];

            for (int i = 0; i < allLines.Length; i++)
                data[i] = allLines[i].Split(',');

            int maxIndex = data.Length - 1;
            for (int i = 0; i < allLines.Length; i++)
            {
                double[] doubleData = new double[data[i].Length - 1];
                for (int j = 1; j < data[i].Length; j++)
                {
                    double.TryParse(data[i][j], out double temp);
                    doubleData[j - 1] = temp;
                }
                variablesList.Add(doubleData);
            }

            //Normalize
            double minTemp = variablesList[0][0];
            double maxTemp = variablesList[0][0];
            double minP = variablesList[0][1];
            double maxP = variablesList[0][1];
            for (int i = 1; i < allLines.Length; i++)
            {
                if (minTemp > variablesList[i][0]) minTemp = variablesList[i][0];
                if (maxTemp < variablesList[i][0]) maxTemp = variablesList[i][0];
                if (minP > variablesList[i][1]) minP = variablesList[i][1];
                if (maxP < variablesList[i][1]) maxP = variablesList[i][1];
            }

            //Get Min/Max values
            for (int i = 0; i < allLines.Length; i++)
            {
                variablesList[i][0] = System.Math.Round((variablesList[i][0] - minTemp) / (maxTemp - minTemp), 2);
                variablesList[i][1] = System.Math.Round((variablesList[i][1] - minP) / (maxP - minP), 2);
            }

            for (int i = 0; i < variablesList.Count - 7; i++)
            {
                double[] set = new double[35];
                variablesList[i].CopyTo(set, 0);
                variablesList[i + 1].CopyTo(set, variablesList[i].Length);
                variablesList[i + 2].CopyTo(set, variablesList[i].Length + variablesList[i + 1].Length);
                variablesList[i + 3].CopyTo(set, variablesList[i].Length + variablesList[i + 2].Length + variablesList[i + 3].Length);
                variablesList[i + 4].CopyTo(set, variablesList[i].Length + variablesList[i + 2].Length + variablesList[i + 3].Length + variablesList[i + 4].Length);
                variablesList[i + 5].CopyTo(set, variablesList[i].Length + variablesList[i + 2].Length + variablesList[i + 3].Length + variablesList[i + 4].Length + variablesList[i + 5].Length);
                variablesList[i + 6].CopyTo(set, variablesList[i].Length + variablesList[i + 2].Length + variablesList[i + 3].Length + variablesList[i + 4].Length + variablesList[i + 5].Length + variablesList[i + 6].Length);
                trainingInputs.Add(set);
                trainingTargets.Add(variablesList[i + 7]);
            }

            Random random = new Random();

            for (int i = 0; i < trainingInputs.Count; i++)
            {
                int rand = random.Next(i, trainingInputs.Count - 1);
                double[] temp = trainingInputs[i];
                trainingInputs[i] = trainingInputs[rand];
                trainingInputs[rand] = temp;
                temp = trainingTargets[i];
                trainingTargets[i] = trainingTargets[rand];
                trainingTargets[rand] = temp;
            }

            int setLength = (int)(trainingInputs.Count * 0.2);
            for (int i = 0; i < setLength; i++)
            {
                testInputs.Add(trainingInputs[0]);
                trainingInputs.RemoveAt(0);
                testTargets.Add(trainingTargets[0]);
                trainingTargets.RemoveAt(0);
            }
        }
    }
}
