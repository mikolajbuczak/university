namespace Midterm
{
    using System;
    using System.Text;
    class List<T>
    {
        private T[] data;
        public int Size { get; private set; }

        public List()
        {
            this.Size = 0;
            this.data = null;
        }

        public List(T[] array)
        {
            this.Size = array.Length;
            this.data = new T[this.Size];
            for (int i = 0; i < this.Size; i++)
                this.data[i] = array[i];
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Push(T value)
        {
            this.Resize(++Size);
            this.data[Size - 1] = value;
        }

        public T Pop()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException("List empty.");
            T returnValue = this.data[this.Size - 1];
            this.Resize(--Size);
            return returnValue;
        }

        public void Insert(T value, int index)
        {
            if (index < 0 || index > this.Size)
                throw new ArgumentException("Index out of bounds.");
            this.Resize(++Size);
            for (int i = this.Size - 1 ; i > index; i--)
                this.data[i] = this.data[i - 1];
            this.data[index] = value;
        }

        public bool Remove(T value)
        {
            int index = this.Find(value);
            if (index == -1) return false;

            for (int i = index; i < this.Size - 1; i++)
                this.data[i] = this.data[i + 1];
            this.Resize(--Size);

            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= this.Size) return false;

            for (int i = index; i < this.Size - 1; i++)
                this.data[i] = this.data[i + 1];
            this.Resize(--Size);

            return true;
        }

        public int Find(T value)
        {
            for (int i = 0; i < this.Size; i++)
                if (this.data[i].Equals(value))
                    return i;
            return -1;
        }

        private void Resize(int size)
        {
            if (size == 0) this.data = null;
            T[] newData = new T[size];
            for (int i = 0; i < this.Size - 1; i++)
                newData[i] = this.data[i];
            this.data = newData;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < this.Size; i++)
                stringBuilder.Append($"[{i}] {this.data[i]}\n");
            return stringBuilder.ToString();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 && index >= this.data.Length)
                    throw new IndexOutOfRangeException("Index out of range.");

                return this.data[index];
            }
            set => this.Insert(value, index);
        }
    }
}
