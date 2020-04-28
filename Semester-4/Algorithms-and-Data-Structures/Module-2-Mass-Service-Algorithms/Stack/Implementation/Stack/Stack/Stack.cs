namespace Stack
{
    class Stack<T>
    {
        private readonly static int MAX_SIZE = 1000;
        private T[] data;
        private int numberOfElements;

        public Stack()
        {
            numberOfElements = 0;
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
            if (numberOfElements == MAX_SIZE) throw new System.IndexOutOfRangeException("Stack full.");

            T[] newData = new T[numberOfElements + 1];

            for (int i = 0; i < numberOfElements; i++)
                newData[i] = data[i];

            newData[numberOfElements] = value;

            numberOfElements++;
            data = newData;
        }

        public T Pop()
        {
            try
            {
                numberOfElements--;

                T returnValue = data[numberOfElements];

                T[] newData = new T[numberOfElements];

                for (int i = 0; i < numberOfElements; i++)
                    newData[i] = data[i];

                data = newData;

                return returnValue;
            }
            catch (System.NullReferenceException)
            {
                throw new System.NullReferenceException("Stack empty.");
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
            catch(System.NullReferenceException)
            {
                throw new System.NullReferenceException("Stack empty.");
            }
        }
    }
}
