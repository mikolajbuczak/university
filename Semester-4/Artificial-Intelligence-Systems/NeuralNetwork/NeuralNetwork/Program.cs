namespace NeuralNetwork
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    class Program
    {
        static void Main()
        {
            decimal[,] array = { { 1, 2 },
                                 { 3, 5 },
                                 { 2, 1 } };

            Matrix matrix = new Matrix(array);
            Matrix squareMatrix = new Matrix(2, 2, 3);
            Matrix vector = new Matrix(2, 1, 2);
            Matrix mult = matrix.Multiply(vector);
            Matrix power = squareMatrix.Power(5);
            Matrix trasposed = matrix.Transpose();
            Console.ReadKey();
        }
        
    }
}
