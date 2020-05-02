namespace Doubly_Linked_List
{
    using System;
    class Program
    {
        static void Main()
        {
            var doublyLinkedList = new DoublyLinkedList<int>();
            doublyLinkedList.AddFirst(9);
            doublyLinkedList.AddFirst(3);
            doublyLinkedList.AddFirst(6);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddFirst(3);
            doublyLinkedList.AddFirst(5);
            Console.WriteLine(doublyLinkedList);
            doublyLinkedList.Insert(5, 2);
            Console.WriteLine(doublyLinkedList);
            Console.ReadKey();
        }
    }
}
