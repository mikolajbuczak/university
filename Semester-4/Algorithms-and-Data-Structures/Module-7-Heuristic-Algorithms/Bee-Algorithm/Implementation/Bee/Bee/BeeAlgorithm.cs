namespace Bee
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    static class BeeAlgorithm
    {
        static Random random = new Random();
        static int generationsCount = 10000;
        static int population = 1000;
        static int onlookers = 100;
        static int foodSourceCycleLimit = 5;

        public static double[] Minimize(Func<double[], double> function, double lowerBound, double upperBound, int dimensionsCount)
        {
            double[] bestCoords = new double[dimensionsCount];
            double bestFitness = double.MaxValue;
            List<Bee> bees = new List<Bee>();

            for(int i = 0; i < population; i++)
                bees.Add(new Bee() { coords = GetRandomCoords(dimensionsCount, lowerBound, upperBound) });

            for(int gen = 0; gen < generationsCount; gen++)
            {
                double hiveFitness = 0;

                for(int i = 0; i < population; i++)
                {
                    double[] candidate = new double[dimensionsCount];
                    bees[i].coords.CopyTo(candidate, 0);
                    int dim = random.Next(0, dimensionsCount);
                    int randHiveIndex = GetDifferentBeeIndex(i, bees);
                    candidate[dim] = bees[i].coords[dim] + (GetRandomNormal(-1, 1) * (bees[i].coords[dim] - bees[randHiveIndex].coords[dim]));

                    bees[i].currentFitness = function(bees[i].coords);
                    double possibleFitness = function(candidate);

                    if (possibleFitness < bees[i].currentFitness)
                    {
                        bees[i].coords = candidate;
                        bees[i].currentFitness = possibleFitness;
                    }

                    hiveFitness += bees[i].currentFitness;
                }

                for (int j = 0; j < onlookers; j++)
                {
                    double roll = GetRandomNormal(0, hiveFitness);
                    double sum = 0;
                    int index = 0;
                    for (int i = 0; i < bees.Count; i++)
                    {
                        if (roll >= sum && roll <= sum + bees[i].lastFitness)
                            index = i;
                        sum += bees[i].lastFitness;
                    }



                    if (bees[index].currentFitness >= bees[index].lastFitness)
                    {
                        bees[index].timesImprovementFailed++;
                    }

                    if (bees[index].timesImprovementFailed >= foodSourceCycleLimit)
                    {
                        bees[index].coords = GetRandomCoords(dimensionsCount, lowerBound, upperBound);
                    }
                    else
                    {
                        bees[index].lastFitness = bees[index].currentFitness;
                    }
                }

                double[] bestCandidate = bees.Aggregate((x, y) => x.currentFitness < y.currentFitness ? x : y).coords;
                double candidateFitness = function(bestCandidate);
                if (candidateFitness < bestFitness)
                {
                    bestCoords = bestCandidate;
                    bestFitness = candidateFitness;
                }
            }

            return bestCoords;
        }

        class Bee
        {
            public double[] coords;
            public double currentFitness = double.MaxValue;
            public double lastFitness = double.MaxValue;
            public int timesImprovementFailed = 0;
        }

        static double[] GetRandomCoords(int dimensionsCount, double lowerBound, double upperBound)
        {
            double[] result = new double[dimensionsCount];
            for(int i = 0; i < dimensionsCount; i++)
                result[i] = random.NextDouble() * (upperBound - lowerBound) + lowerBound;

            return result;
        }

        static double GetRandomNormal(double lowerBound, double upperBound)
        {
            return random.NextDouble() * (upperBound - lowerBound) + lowerBound;
        }

        static int GetDifferentBeeIndex(int currentBeeIndex, List<Bee> bees)
        {
            int newIndex = currentBeeIndex;
            while (newIndex == currentBeeIndex)
                newIndex = random.Next(bees.Count);
            return newIndex;
        }
    }
}
