namespace Midterm
{
    using System.IO;
    using System;
    using System.Globalization;

    class Program
    {
        static void Main()
        {
            //Load data
            double[][] data = ConvertData(File.ReadAllLines("iris.data"));

            //Normalize data
            Normalize(ref data);

            //Shuffle dlate
            Shuffle(ref data);

            //Split data onto training set and test set (80% - training set, 20% - test set)
            int upperBound = (int)(data.Length * 0.8);
            int lowerBound = upperBound + 1;
            double[][] trainingSet = GetTrainingSet(data, upperBound);
            double[][] testSet = GetTestSet(data, lowerBound);

            List<Item> trainingItems = new List<Item>();
            for (int i = 0; i < trainingSet.Length; i++)
                trainingItems.Push(new Item(trainingSet[i]));

            List<Item> testItems = new List<Item>();
            for (int i = 0; i < testSet.Length; i++)
                testItems.Push(new Item(testSet[i]));

            Tree tree = new Tree(trainingItems);

            tree.ConstructTree();

            Console.WriteLine($"GuessRate: {Math.Round(tree.Test(testItems)*100, 2)}%");
            Console.ReadKey();
        }

        private static double[][] ConvertData(string[] allLines)
        {
            string[][] rawData = new string[allLines.Length][];
            for (int i = 0; i < allLines.Length; i++)
                rawData[i] = allLines[i].Split(',');

            int lastColumn = rawData[0].Length - 1;

            double[][] returnTable = new double[rawData.Length][];
            for(int i = 0; i < rawData.Length; i++)
            {
                returnTable[i] = new double[rawData[i].Length];
                for  (int j = 0; j < lastColumn; j++)
                    Double.TryParse(rawData[i][j], NumberStyles.Any, CultureInfo.InvariantCulture, out returnTable[i][j]);

                /*
                 *     Iris-setosa - 0
                 * Iris-versicolor - 1
                 *  Iris-virginica - 2
                 */

                if (rawData[i][lastColumn] == "Iris-setosa") returnTable[i][4] = 0;
                else if (rawData[i][lastColumn] == "Iris-versicolor") returnTable[i][4] = 1;
                else if (rawData[i][lastColumn] == "Iris-virginica") returnTable[i][4] = 2;
            }
            return returnTable;
        }

        public static void Normalize(ref double[][] table)
        {
            int columnsToNormalize = table[0].Length - 1;
            double nmin = 0;
            double nmax = 1;
            for (int j = 0; j < columnsToNormalize; j++)
            {
                double min = table[0][j];
                double max = table[0][j];
                for (int i = 0; i < table.Length - 1; i++)
                {
                    if(table[i][j] < min)
                        min = table[i][j];
                    if (table[i][j] > max)
                        max = table[i][j]; 
                }
                for (int i = 0; i < table.Length; i++)
                    table[i][j] = Math.Round((double)(((table[i][j] - min) / (max - min))) * (nmax - nmin) + nmin, 10);
            }
        }

        public static void Shuffle(ref double[][] data)
        {
            Random rng = new Random();
            int n = data.Length;
            while (n > 1)
            {
                n--;
                int randomIndex = rng.Next(data.Length);
                double[] temp = data[randomIndex];
                data[randomIndex] = data[n];
                data[n] = temp;
            }
        }

        private static double[][] GetTrainingSet(double[][] data, int upperBound)
        {
            double[][] returnTable = new double[upperBound + 1][];
            for (int i = 0; i <= upperBound; i++)
            {
                returnTable[i] = new double[data[i].Length];
                for (int j = 0; j < data[i].Length; j++)
                    returnTable[i][j] = data[i][j];
            }
            return returnTable;
        }

        private static double[][] GetTestSet(double[][] data, int lowerBound)
        {
            double[][] returnTable = new double[data.Length - lowerBound][];
            for (int i = lowerBound; i < data.Length; i++)
            {
                returnTable[i - lowerBound] = new double[data[i].Length];
                for (int j = 0; j < data[i].Length; j++)
                    returnTable[i - lowerBound][j] = data[i][j];
            }
            return returnTable;
        }
    }
}
