namespace Circular_Linked_List
{
    using System;
    using System.Text;
    class CircularLinkedList<T>
    {
        private ListElement tail;
        public int Size { get; private set; }

        public CircularLinkedList()
        {
            Size = 0;
            tail = null;
        }

        public bool IsEmpty()
        {
            return tail == null;
        }

        public void AddFirst(T value)
        {
            if (value == null) throw new ArgumentNullException("Value is null.");
            if (IsEmpty())
            {
                tail = new ListElement(value);
                tail.next = tail;
                Size++;
                return;
            }
            ListElement newElement = new ListElement(value);
            newElement.next = tail.next;
            tail.next = newElement;

            Size++;
        }

        public void AddLast(T value)
        {
            if (value == null) throw new ArgumentNullException("Value is null.");
            if (IsEmpty())
            {
                tail = new ListElement(value);
                tail.next = tail;
                Size++;
                return;
            }
            ListElement newElement = new ListElement(value);
            newElement.next = tail.next;
            tail.next = newElement;
            tail = newElement;

            Size++;
        }

        public bool Insert(T value, int index)
        {
            if (index < 0 || index > Size) return false;
            if (index == 0)
            {
                AddFirst(value);
                return true;
            }
            if (index == Size)
            {
                AddLast(value);
                return true;
            }
            ListElement element = tail.next;
            while (--index > 0)
                element = element.next;

            ListElement newElement = new ListElement(value);
            newElement.next = element.next;
            element.next = newElement;
            Size++;
            return true;
        }

        public bool Remove(T value)
        {
            if (value.Equals(null)) return false;
            if (Find(value) == -1) return false;
            if (Size == 1)
            {
                tail = null;
                Size--;
                return true;
            }
            ListElement element = tail.next;
            while (!element.next.value.Equals(value))
                element = element.next;
            if (element.next == tail)
                tail = element;
            element.next = element.next.next;
            Size--;
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > (Size - 1)) return false;
            if (Size == 1)
            {
                tail = null;
                Size--;
                return true;
            }
            ListElement element = tail.next;
            while (--index > 0)
                element = element.next;
            if (element.next == tail)
                tail = element;
            element.next = element.next.next;
            Size--;
            return true;
        }

        public int Find(T value)
        {
            ListElement element = tail.next;
            for(int i = 0; i < Size; i++)
            {
                if (element.value.Equals(value)) return i;
                element = element.next;
            }
            return -1;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "Circular linked list empty.";
            var stringBuilder = new StringBuilder();
            ListElement element = tail.next;
            for(int i = 0; i < Size; i++)
            {
                stringBuilder.Append($"[{i}] {element.value}\n");
                element = element.next;
            }
            stringBuilder.Append("...\n");
            for (int i = 0; i < Size; i++)
            {
                stringBuilder.Append($"[{i}] {element.value}\n");
                element = element.next;
            }
            stringBuilder.Append("...\n\n");
            return stringBuilder.ToString();
        }

        private class ListElement
        {
            public T value;
            public ListElement next;

            public ListElement(T _value)
            {
                this.value = _value;
                this.next = null;
            }
        }
    }
}
