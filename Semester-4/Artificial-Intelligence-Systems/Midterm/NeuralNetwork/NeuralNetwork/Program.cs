namespace NeuralNetwork
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            //Create a neural network
            var neuralNetwork = new NeuralNetwork(2, 2, 1);

            //Initialize default weights between a input layer and a hidden layer
            double[,] initialInputHiddenWeights = { { 0.12, 0.12 },
                                                    { 0.10, 0.08 } };

            //Initialize default weights between a input layer and a hidden layer
            double[,] initialHiddenOutputWeights = { { 0.14, 0.15 } };

            //Set default weights
            neuralNetwork.SetInitialWieghts(initialInputHiddenWeights, initialHiddenOutputWeights);

            //Initialize inputs
            List<double[]> inputs = new List<double[]>();
            inputs.Add(new double[]{3, 4});

            //Initialize outputs
            List<double[]> targets = new List<double[]>();
            targets.Add(new double[] { 1 });

            Random random = new Random();
            Console.WriteLine("Started training...");

            //Train neural network
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Iteration: {i + 1}");
                //Pick a random input
                int index = random.Next(inputs.Count - 1);
                neuralNetwork.Train(inputs[index], targets[index]);
            }

            Console.WriteLine("\nTraining finished...\n");
    
            //Test neural network
            for(int i = 0; i < inputs.Count; i++)
            {
                double[] guess = neuralNetwork.Guess(inputs[i]);

                //Display guesses
                for (int j = 0; j < guess.Length; j++)
                    Console.WriteLine($"For data [{string.Join(", ", inputs[i])}] with known answer [{string.Join("", targets[i])}] neural network guessed: {guess[j]}");
            }
            Console.ReadKey();
        }
    }
}
