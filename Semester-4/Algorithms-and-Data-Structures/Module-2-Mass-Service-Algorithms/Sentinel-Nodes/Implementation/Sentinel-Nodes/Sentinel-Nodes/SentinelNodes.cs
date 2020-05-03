namespace Sentinel_Nodes
{
    using System;
    using System.Text;
    class SentinelNodes<T>
    {
        private ListElement head;
        public int Size { get; private set; }

        public SentinelNodes()
        {
            Size = 0;
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void AddFirst(T value)
        {
            if (value == null) throw new ArgumentNullException("Value is null.");
            ListElement element = new ListElement(value);
            element.next = head;
            head = element;
            Size++;
        }

        public void AddLast(T value)
        {
            if (value == null) throw new ArgumentNullException("Value is null.");
            if (head == null)
            {
                AddFirst(value);
                return;
            }
            ListElement element = head;
            while (element.next != null)
                element = element.next;

            element.next = new ListElement(value);
            Size++;
        }

        public bool Insert(T value, int index)
        {
            if (value == null) return false;
            if (index < 0 || index > Size) return false;
            if (index == 0)
            {
                AddFirst(value);
                return true;
            }
            ListElement element = head;
            while (--index > 0)
            {
                element = element.next;
            }
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
            if (head.value.Equals(value))
            {
                head = head.next;
                return true;
            }
            ListElement element = head;
            while (!element.next.value.Equals(value))
                element = element.next;
            while (element.next != null)
                element.next = element.next.next;
            Size--;
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > (Size - 1)) return false;
            if (Size == 1)
            {
                head = null;
                Size--;
                return true;
            }
            if (index == 0)
            {
                head = head.next;
                Size--;
                return true;
            }
            ListElement element = head;
            while (--index > 0)
            {
                element = element.next;
            }
            element.next = element.next.next;
            Size--;
            return true;
        }

        public int Find(T value)
        {
            AddLast(value);
            int index = 0;
            ListElement element = head;
            while (!element.value.Equals(value))
            {
                element = element.next;
                index++;
            }

            if (index == (Size - 1))
            {
                RemoveAt(Size - 1);
                return -1;
            }
            RemoveAt(Size - 1);
            return index;
        }

        public override string ToString()
        {
            if (head == null) return "Linked list empty.";
            var stringBuilder = new StringBuilder();
            ListElement element = head;
            int index = 0;
            while (element != null)
            {
                stringBuilder.Append($"[{index++}] {element.value}\n");
                element = element.next;
            }
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
