namespace Circular_Linked_List
{
    using System;
    class Program
    {     
        static void Main()
        {
            var circularLinkedList = new CircularLinkedList<int>();

            circularLinkedList.AddLast(5);
            Console.WriteLine(circularLinkedList);
            circularLinkedList.RemoveAt(0);
            Console.WriteLine(circularLinkedList);
            Console.ReadKey();
        }
    }
}
