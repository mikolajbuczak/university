namespace Floyd_Warshall
{
    using System;
    class Program
    {
        static void Main()
        {
            Graph graph = new Graph();

            #region AddVertex
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            #endregion

            #region AddConnection
            graph.AddConnection(0, 2, -2);
            graph.AddConnection(2, 3, 2);
            graph.AddConnection(3, 1, -1);
            graph.AddConnection(1, 0, 4);
            graph.AddConnection(1, 2, 3);
            #endregion

            int[,] table = graph.FloydWarshall();

            for(int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                    Console.Write($"{table[i, j]} ");
                Console.Write('\n');
            }      

            Console.ReadKey();
        }
    }
}
