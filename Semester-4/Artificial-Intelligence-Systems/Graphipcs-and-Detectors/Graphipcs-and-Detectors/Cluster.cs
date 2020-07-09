namespace Graphipcs_and_Detectors
{
    using System;
    static class Cluster
    {
        public static void Clusterize(IrisDataset trainingDataset, IrisDataset testDataset)
        {
            int correct = 0;
            foreach(var current in testDataset.data)
            {
                Iris minimum = trainingDataset.data[0];

                foreach (var iris in trainingDataset.data)
                {
                    if (iris == current) continue;
                    if (CalculateDistance(iris, current) < CalculateDistance(minimum, current)) minimum = iris;
                }

                if (current.Type == minimum.Type) correct++;
                Console.WriteLine($"Correct tpe: {current.Type}");
                Console.WriteLine($"Predicted tpe: {minimum.Type}");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine($"Accuracy: {correct}/{testDataset.data.Count}");
        }

        static double CalculateDistance(Iris a, Iris b)
        {
            return Math.Sqrt(Math.Pow(a.SepalLength - b.SepalLength, 2) +
                             Math.Pow(a.SepalWidth  - b.SepalWidth,  2) +
                             Math.Pow(a.PetalLength - b.PetalLength, 2) +
                             Math.Pow(a.PetalWidth  - b.PetalWidth,  2));
        }
    }
}
