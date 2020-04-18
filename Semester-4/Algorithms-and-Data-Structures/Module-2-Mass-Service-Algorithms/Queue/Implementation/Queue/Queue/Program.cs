namespace Queue
{
    class Program
    {
        static void Main()
        {
            var queue = new Queue<int>();

            queue.Enqueue(5);

            System.Console.WriteLine(queue.IsEmpty());
            System.Console.WriteLine(queue.Peek());
            queue.Enqueue(2);
            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue.Peek());
            System.Console.WriteLine(queue.IsEmpty());
            System.Console.WriteLine(queue.Dequeue());

            System.Console.ReadKey();
        }
    }
}
