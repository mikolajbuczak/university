namespace Dijkstra
{
    using System;
    class Program
    {
        static void Main()
        {
            Graph graph = new Graph();

            #region AddVertex
            graph.AddVertex('0');
            graph.AddVertex('1');
            graph.AddVertex('2');
            graph.AddVertex('3');
            graph.AddVertex('4');
            graph.AddVertex('5');
            graph.AddVertex('6');
            graph.AddVertex('7');
            graph.AddVertex('8');
            #endregion

            #region AddConnection
            graph.AddConnection('0', '1', 5);
            graph.AddConnection('0', '3', 2);
            graph.AddConnection('0', '4', 8);
            graph.AddConnection('1', '4', 2);
            graph.AddConnection('2', '1', 3);
            graph.AddConnection('2', '5', 4);
            graph.AddConnection('3', '4', 7);
            graph.AddConnection('3', '6', 8);
            graph.AddConnection('4', '5', 9);
            graph.AddConnection('4', '7', 4);
            graph.AddConnection('5', '1', 6);
            graph.AddConnection('6', '7', 9);
            graph.AddConnection('7', '3', 5);
            graph.AddConnection('7', '5', 3);
            graph.AddConnection('7', '8', 5);
            graph.AddConnection('8', '5', 3);
            #endregion

            Console.WriteLine(graph.Dijkstra('0', '5'));
            Console.ReadKey();
        }
    }
}
