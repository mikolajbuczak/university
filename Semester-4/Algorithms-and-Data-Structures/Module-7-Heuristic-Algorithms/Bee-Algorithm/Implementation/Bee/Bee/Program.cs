namespace Bee
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main()
        {

            double[] sphere = BeeAlgorithm.Minimize(Sphere, -10, 10, 1);
            DisplayArray(sphere);

            double[] sumSquares = BeeAlgorithm.Minimize(SumSquares, -10, 10, 1);
            DisplayArray(sumSquares);

            Console.ReadKey();
        }

        static double Sphere(double[] coords)
        {
            for (int i = 0; i < coords.Length; i++)
                coords[i] *= coords[i];

            return coords.Sum();
        }

        static double SumSquares(double[] coords)
        {
            double result = 0;
            for(int i = 0; i < coords.Length; i++)
                result += ((i + 1) * coords[i] * coords[i]);

            return result;
        }

        static void DisplayArray(double[] array)
        {
            foreach(var element in array)
                Console.Write($"{element} ");
            Console.WriteLine('\n');
        }
    }
}
