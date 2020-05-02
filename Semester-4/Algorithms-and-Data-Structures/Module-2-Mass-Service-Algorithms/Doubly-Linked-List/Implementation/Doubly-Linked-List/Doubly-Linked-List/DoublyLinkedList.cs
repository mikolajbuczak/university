namespace Doubly_Linked_List
{
    using System;
    using System.Text;
    class DoublyLinkedList<T>
    {
        private ListElement head;
        private ListElement tail;
        public int Size { get; private set; }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void AddFirst(T value)
        {
            if (IsEmpty())
            {
                head = tail = new ListElement(value);
                Size++;
                return;
            }
            ListElement element = head;
            head = new ListElement(value);
            element.previous = head;
            head.next = element;
            Size++;
        }

        public void AddLast(T value)
        {
            if (IsEmpty())
            {
                head = tail = new ListElement(value);
                Size++;
                return;
            }
            ListElement element = tail;
            tail = new ListElement(value);
            element.next = tail;
            tail.previous = element;
            Size++;
        }

        public bool Insert(T value, int index)
        {
            if (Size < index) return false;
            ListElement newElement = new ListElement(value);
            if (index == 0)
            {
                AddFirst(value);
                return true;
            }
            if(index == Size - 1)
            {
                AddLast(value);
                return true;
            }
            ListElement element = head;
            while (--index > 0)
            {
                element = element.next;
            }
            element.next.previous = newElement;
            newElement.previous = element;
            newElement.next = element.next;
            element.next = newElement;
            Size++;
            return true;
        }

        public bool Remove(T value)
        {
            if (value.Equals(null)) return false;
            if (Find(value) == -1) return false;
            if (head.value.Equals(value))
            {
                head = head.next;
                head.previous = null;
                return true;
            }
            if (tail.value.Equals(value))
            {
                tail = head.previous;
                tail.next = null;
                return true;
            }
            ListElement element = head;
            while (!element.next.value.Equals(value))
                element = element.next;

            element.next = element.next.next;
            element.next.previous = element;

            Size--;
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (Size < index) return false;
            if (index == 0)
            {
                head = head.next;
                head.previous = null;
                return true;
            }
            if(index == Size - 1)
            {
                tail = tail.previous;
                tail.next = null;
                return true;
            }
            ListElement element = head;
            while (--index > 0)
            {
                element = element.next;
            }
            element.next = element.next.next;
            element.next.previous = element;
            Size--;
            return true;
        }

        public int Find(T value)
        {
            int index = 0;
            ListElement element = head;
            while (element != null)
            {
                if (element.value.Equals(value))
                    return index;
                element = element.next;
                index++;
            }
            return -1;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "Doubly linked list empty.";
            var stringBuilder = new StringBuilder();
            int index = 0;
            ListElement element = head;
            stringBuilder.Append($"[{index++}]\t[NULL|{element.value}|{element.next.value}]\n");
            element = element.next;
            while (element.next != null)
            {
                stringBuilder.Append($"[{index++}]\t[{element.previous.value}|{element.value}|{element.next.value}]\n");
                element = element.next;
            }
            stringBuilder.Append($"[{index++}]\t[{element.previous.value}|{element.value}|NULL]\n");
            return stringBuilder.ToString();
        }

        private class ListElement
        {
            public ListElement previous;
            public T value;
            public ListElement next;

            public ListElement(T _value)
            {
                this.previous = null;
                this.value = _value;
                this.next = null;
            }
        }
    }
}
