namespace Priority_Queue
{
    using System;
    class Program
    {
        static void Main()
        {
            var priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(5, 12);
            priorityQueue.Enqueue(2, 13);
            priorityQueue.Enqueue(7, 9);
            priorityQueue.Enqueue(3, 12);
            priorityQueue.Enqueue(99, 5);
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            priorityQueue.Enqueue(13, -2);
            priorityQueue.Enqueue(23, 5);
            priorityQueue.Enqueue(9449, 4);
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
            Console.ReadKey();
        }
    }
}
