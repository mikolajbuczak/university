namespace Sentinel_Nodes
{
    using System;
    class Program
    {      
        static void Main()
        {
            var sentinelNodes = new SentinelNodes<int>();
            sentinelNodes.AddFirst(5);
            sentinelNodes.AddFirst(6);
            sentinelNodes.AddFirst(7);
            sentinelNodes.AddFirst(8);
            Console.WriteLine(sentinelNodes.Find(7));
            Console.ReadKey();
        }
    }
}
