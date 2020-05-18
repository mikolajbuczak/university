namespace Particle
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class ParticleSwarmAlgorithm
    {
        static Random random = new Random();
        static int generationsCount = 10000;
        static int particleCount = 100;
        static double velocityFactor = 0.5;
        static double bestPositionFactor = 0.75;
        static double bestSwarmPositionFactor = 2;

        public static double[] Minimize(Func<double[], double> function, double lowerBound, double upperBound, int dimensionsCount)
        {
            List<Particle> particles = new List<Particle>();
            double[] bestSwarmPosition = GetRandomCoords(dimensionsCount, lowerBound, upperBound);
            double bestValue = function(bestSwarmPosition);

            for (int i = 0; i < particleCount; i++)
            {
                particles.Add(new Particle(GetRandomCoords(dimensionsCount, lowerBound, upperBound), GetRandomCoords(dimensionsCount, -1.0, 1.0)));

                double currentValue = function(particles.Last().bestPosition);

                if (currentValue < bestValue)
                {
                    bestSwarmPosition = particles.Last().bestPosition;
                    bestValue = currentValue;
                }
            }

            for (int i = 0; i < generationsCount; i++)
            {
                foreach (Particle p in particles)
                {
                    for (int dim = 0; dim < dimensionsCount; dim++)
                    {
                        double randomPositionFactor = random.NextDouble();
                        double randomSwarmFactor = random.NextDouble();

                        p.velocity[dim] = (p.velocity[dim] * velocityFactor) + bestPositionFactor * randomPositionFactor * (p.bestPosition[dim] - p.position[dim]) +
                        bestSwarmPositionFactor * randomSwarmFactor * (bestSwarmPosition[dim] - p.position[dim]);
                    }

                    for (int dim = 0; dim < dimensionsCount; dim++)
                    {
                        p.position[dim] += p.velocity[dim];
                    }

                    if (function(p.position) < function(p.bestPosition))
                        p.bestPosition = p.position;

                    if (function(p.position) < function(bestSwarmPosition))
                        bestSwarmPosition = p.position;
                }
            }
            return bestSwarmPosition;
        }

        class Particle
        {
            public double[] velocity;
            public double[] position;
            public double[] bestPosition;

            public Particle(double[] _position, double[] _velocity)
            {
                position = _position;
                velocity = _velocity;
                bestPosition = position;
            }
        }

        static double[] GetRandomCoords(int dimensionsCount, double lowerBound, double upperBound)
        {
            double[] result = new double[dimensionsCount];
            for (int i = 0; i < dimensionsCount; i++)
                result[i] = random.NextDouble() * (upperBound - lowerBound) + lowerBound;

            return result;
        }

        static double GetRandomNormal(double lowerBound, double upperBound)
        {
            return random.NextDouble() * (upperBound - lowerBound) + lowerBound;
        }
    }
}
