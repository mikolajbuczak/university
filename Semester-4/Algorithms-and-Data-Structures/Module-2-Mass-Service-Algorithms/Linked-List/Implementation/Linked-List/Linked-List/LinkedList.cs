namespace Linked_List
{
    using System;
    using System.Text;
    class LinkedList<T>
    {
        private ListElement head;
        public int Size { get; private set; }

        public LinkedList()
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
            ListElement temp = new ListElement(value);
            temp.next = head;
            head = temp;
            Size++;
        }

        public void AddLast(T value)
        {
            if (head == null)
            {
                AddFirst(value);
                return;
            }
            ListElement tmp = head;
            while (tmp.next != null)
                tmp = tmp.next;

            tmp.next = new ListElement(value);
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
            ListElement temp = head;
            while (--index > 0)
            {
                temp = temp.next;
            }
            newElement.next = temp.next;
            temp.next = newElement;
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
            while(element.next != null)
                element.next = element.next.next;
            Size--;
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (Size < index) return false;
            if(index == 0)
            {
                head = head.next;
                return true;
            }
            ListElement temp = head;
            while(--index > 0)
            {
                temp = temp.next;
            }
            temp.next = temp.next.next;
            Size--;
            return true;
        }

        public int Find(T value)
        {
            int index = 0;
            ListElement element = head;
            while(element != null)
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
            if (head == null) return "Linked list empty.";
            var stringBuilder = new StringBuilder();
            ListElement element = head;
            int index = 0;
            while(element != null)
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
