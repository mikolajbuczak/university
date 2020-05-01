namespace Stack
{
    using System;
    class Program
    {
        static void Main()
        {
            var stack = new Stack<int>();

            stack.Push(5);
            stack.Push(2);
            stack.Push(7);
            stack.Push(12);
            stack.Push(99);
            Console.WriteLine(stack);
            stack.Pop();
            stack.Push(13);
            stack.Push(23);
            stack.Push(9449);
            Console.WriteLine(stack);
            stack.Pop();
            Console.WriteLine(stack);
            Console.ReadKey();
        }
    }
}
