namespace Graphipcs_and_Detectors
{
    using System;
    class Program
    {
        static void Main()
        {
            //Graphics
            Console.WriteLine("Graphics:");
            Graphics.GetKeyPointsPicture(@"file.jpg", @"points.jpg");
            Console.WriteLine();
            Console.WriteLine();

            //Bayes Naive Classificator
            Dataset dataset = new Dataset(@"data.csv");
            Data testData = new Data("Sunny", "Cool", "High", true, false);
            testData.PlayGolf = Bayes.Guess(dataset, testData);
            Console.WriteLine("Bayes Naive Classificator:");
            Console.WriteLine("For weather:");
            Console.WriteLine($"Outlook - {testData.Outlook}, Temperature - {testData.Temperature}, Humidity - {testData.Humidity}, Windy - {testData.Windy}");
            Console.Write("Bayes Naive Classificator guessed ");
            if (testData.PlayGolf)
                Console.WriteLine("you can play golf.");
            else
                Console.WriteLine("you can\'t play golf.");
            Console.WriteLine();
            Console.WriteLine();

            //Cluster Analisys
            IrisDataset trainingSet = new IrisDataset(@"iris_train.csv");
            IrisDataset testSet = new IrisDataset(@"iris_test.csv");
            Console.WriteLine("Cluster Analisys:");
            Cluster.Clusterize(trainingSet, testSet);
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
