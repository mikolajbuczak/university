namespace Stack
{
    class Stack<T>
    {
        private readonly static int MAX_SIZE = 1000;
        private readonly T[] data = new T [MAX_SIZE];
        private int numberOfElements = 0;

        public Stack()
        {
            for (int i = 0; i < MAX_SIZE; i++)
                data[i] = default;
        }

        public bool IsEmpty()
        {
            return numberOfElements == 0;
        }

        public int Size()
        {
            return numberOfElements;
        }

        public void Push(T value)
        {
            try
            {
                data[numberOfElements] = value;
                numberOfElements++;
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("Stack full.");
            }
        }

        public T Pop()
        {
            try
            {
                T returnValue = data[numberOfElements - 1];
                data[numberOfElements - 1] = default;
                numberOfElements--;
                return returnValue;
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("Stack empty.");
            }
        }

        public T Peek()
        {
            try
            {
                return data[numberOfElements - 1];
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("Stack empty.");
            }
        }
    }
}
