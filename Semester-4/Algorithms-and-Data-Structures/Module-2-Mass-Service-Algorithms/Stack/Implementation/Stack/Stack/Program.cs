namespace Stack
{
    class Program
    {
        static void Main()
        {
            var stack = new Stack<int>();

            stack.Push(5);
            System.Console.WriteLine(stack.IsEmpty());
            System.Console.WriteLine(stack.Peek());
            stack.Push(2);
            System.Console.WriteLine(stack.Pop());
            System.Console.WriteLine(stack.Peek());
            System.Console.WriteLine(stack.IsEmpty());
            System.Console.WriteLine(stack.Pop());
            System.Console.WriteLine(stack.IsEmpty());
            System.Console.ReadKey();
        }
    }
}
