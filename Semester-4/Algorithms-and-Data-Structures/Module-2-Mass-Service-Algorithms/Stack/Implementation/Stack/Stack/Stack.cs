namespace Stack
{
    using System;
    using System.Text;
    class Stack<T>
    {
        private T[] data;
        public int Size { get; private set; }

        public Stack()
        {
            Size = 0;
            data = new T[Size];
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Push(T value)
        {
            Array.Resize(ref data, ++Size);
            data[Size - 1] = value;
        }

        public T Pop()
        {      
            T value = Peek();

            Array.Resize(ref data, --Size);

            return value;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new IndexOutOfRangeException("Stack empty.");

            return data[Size - 1];
        }

        public override string ToString()
        {
            if (IsEmpty()) return "Stack empty.";
            var stringBuilder = new StringBuilder();
            for(int i = Size - 1; i >= 0; i--)
            {
                stringBuilder.Append(data[i]);
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }
    }
}
