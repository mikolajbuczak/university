namespace Linked_List
{
    using System;
    class Program
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddFirst(9);
            linkedList.AddFirst(6);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(5);
            Console.WriteLine(linkedList);
            linkedList.RemoveAt(2);
            Console.WriteLine(linkedList);
            Console.ReadKey();
        }
    }
}
