namespace Priority_Queue
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    class PriorityQueue<T>
    {
        Pair[] data;
        public int Size { get; private set; }

        public PriorityQueue()
        {
            Size = 0;
            data = new Pair[Size];
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Enqueue(T value, int priority)
        {
            Array.Resize(ref data, ++Size);
            data[Size - 1] = new Pair(value, priority);
        }

        public T Dequeue()
        {
            int index = GetHighestPriorityIndex();
            T value = data[index].value;
            for (int i = index; i < Size - 1; i++)
                data[i] = data[i + 1];
            Array.Resize(ref data, --Size);

            return value;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new IndexOutOfRangeException("Priority queue empty.");
            return data[GetHighestPriorityIndex()].value;
        }

        private int GetHighestPriorityIndex()
        {
            int index = 0;
            for(int i = 1; i < Size; i++)
                if (data[i].priority > data[index].priority) index = i;

            return index;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "Priority queue empty.";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{data[0].value} [{data[0].priority}]");
            for(int i = 1; i < Size; i++)
            {
                stringBuilder.Append('\n');
                stringBuilder.Append($"{data[i].value} [{data[i].priority}]");
            }
            stringBuilder.Append('\n');
            return stringBuilder.ToString();
        }

        private struct Pair{
            public T value;
            public int priority;

            public Pair(T _value, int _priority)
            {
                this.value = _value;
                this.priority = _priority;
            }
        }
    }
}
