namespace Prim
{
    using System;
    class Program
    {
        static void Main()
        {
            Graph graph = new Graph();

            #region AddVertecies
            graph.AddVertex('0');
            graph.AddVertex('1');
            graph.AddVertex('2');
            graph.AddVertex('3');
            graph.AddVertex('4');
            graph.AddVertex('5');
            graph.AddVertex('6');
            graph.AddVertex('7');
            graph.AddVertex('8');
            graph.AddVertex('9');
            #endregion

            #region AddConnections
            graph.AddConnection('0', '1', 19);
            graph.AddConnection('0', '4', 12);
            graph.AddConnection('0', '3', 14);
            graph.AddConnection('1', '2', 20);
            graph.AddConnection('1', '4', 18);
            graph.AddConnection('2', '4', 17);
            graph.AddConnection('2', '5', 15);
            graph.AddConnection('2', '9', 29);
            graph.AddConnection('3', '4', 13);
            graph.AddConnection('3', '6', 28);
            graph.AddConnection('4', '5', 16);
            graph.AddConnection('4', '6', 21);
            graph.AddConnection('4', '7', 22);
            graph.AddConnection('4', '8', 24);
            graph.AddConnection('5', '8', 26);
            graph.AddConnection('5', '9', 27);
            graph.AddConnection('6', '7', 23);
            graph.AddConnection('7', '8', 30);
            graph.AddConnection('8', '9', 35);
            #endregion

            Console.WriteLine(graph);
            Console.WriteLine(graph.Prim());

            Console.ReadKey();
        }
    }
}
