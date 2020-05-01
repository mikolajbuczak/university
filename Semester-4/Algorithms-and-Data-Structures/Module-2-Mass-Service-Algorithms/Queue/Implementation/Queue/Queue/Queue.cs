namespace Queue
{
    using System;
    using System.Text;
    class Queue <T>
    {
        private T[] data;
        public int Size { get; private set; }

        public Queue()
        {
            Size = 0;
            data = new T[Size];
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Enqueue(T value)
        {
            Array.Resize(ref data, ++Size);

            data[Size - 1] = value;
        }

        public T Dequeue()
        {
            T value = Peek();
            for (int i = 0; i < Size - 1; i++)
                data[i] = data[i + 1];
            Array.Resize(ref data, --Size);

            return value;
        }

        public T Peek()
        {
            if(IsEmpty()) throw new IndexOutOfRangeException("Queue empty.");
            return data[0];
        }

        public override string ToString()
        {
            if (IsEmpty()) return "Queue empty.";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(data[0]);
            for(int i = 1; i < Size; i++)
            {
                stringBuilder.Append(", ");
                stringBuilder.Append(data[i]);
            }
            stringBuilder.Append('\n');
            return stringBuilder.ToString();
        }
    }
}
