namespace Queue
{
    using System;
    class Program
    {
        static void Main()
        {
            var queue = new Queue<int>();

            queue.Enqueue(5);
            queue.Enqueue(2);
            queue.Enqueue(7);
            queue.Enqueue(12);
            queue.Enqueue(99);
            Console.WriteLine(queue);
            queue.Dequeue();
            queue.Enqueue(13);
            queue.Enqueue(23);
            queue.Enqueue(9449);
            Console.WriteLine(queue);
            queue.Dequeue();
            Console.WriteLine(queue);
            Console.ReadKey();
        }
    }
}
