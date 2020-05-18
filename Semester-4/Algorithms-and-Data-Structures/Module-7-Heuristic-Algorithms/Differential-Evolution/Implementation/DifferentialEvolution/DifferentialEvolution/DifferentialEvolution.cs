namespace DifferentialEvolution
{
    using System;
    using System.Collections.Generic;
    static class DifferentialEvolution
    {
        static Random rnd = new Random();
        static int iterCount = 5000;
        static int initialPopulation = 1000;
        static double crossoverProbability = 0.5;
        static double differentialWeight = 1.0;


        public static double[] Minimize(Func<double[], double> function, double lowerBound, double upperBound, int dimensionsCount)
        {
            List<double[]> pop = new List<double[]>();
            for (int i = 0; i < initialPopulation; i++)
            {
                pop.Add(GenerateRandomAgent(dimensionsCount));
            }

            for (int i = 0; i < iterCount; i++)
            {
                for (int j = 0; j < pop.Count; j++)
                {
                    double[][] referenceAgents = PickReferenceAgents(pop, j);
                    double[] potential = new double[dimensionsCount];

                    for (int k = 0; k < dimensionsCount; k++)
                    {
                        double r = rnd.NextDouble();

                        if (r < crossoverProbability)
                            potential[k] = referenceAgents[0][k] + differentialWeight * (referenceAgents[1][k] - referenceAgents[2][k]);

                        if (potential[k] < lowerBound)
                            potential[k] = lowerBound;

                        if (potential[k] > upperBound)
                            potential[k] = upperBound;
                    }
                    if (function(potential) <= function(pop[j]))
                        pop[j] = potential;
                }
            }


            double[] bestAgent = pop[0];
            foreach (double[] agent in pop)
            {
                if (function(agent) <= function(bestAgent))
                    bestAgent = agent;
            }

            return bestAgent;
        }

        static double[] GenerateRandomAgent(int n)
        {
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = rnd.NextDouble();
            }
            return d;
        }

        static double[][] PickReferenceAgents(List<double[]> population, int AgentIndex)
        {
            if (population.Count < 4)
                throw new Exception("Constraint not satisfied: Population smaller than 4, algorithm cannot proceed");

            List<double[]> tempPop = new List<double[]>(population);
            double[][] result = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                int index = rnd.Next(0, tempPop.Count);
                result[i] = tempPop[index];
                tempPop.RemoveAt(index);
            }
            return result;
        }
    }
}
