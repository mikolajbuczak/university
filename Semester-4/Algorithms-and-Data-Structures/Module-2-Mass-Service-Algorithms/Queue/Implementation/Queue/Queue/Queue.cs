namespace Queue
{
    class Queue <T>
    {
        private readonly static int MAX_SIZE = 1000;
        private T[] data;
        private int numberOfElements;

        public Queue()
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

        public void Enqueue(T value)
        {
            if (numberOfElements == MAX_SIZE) throw new System.IndexOutOfRangeException("Queue full.");

            T[] newData = new T[numberOfElements + 1];

            for (int i = 0; i < numberOfElements; i++)
                newData[i] = data[i];

            newData[numberOfElements] = value;

            numberOfElements++;

            data = newData;
        }

        public T Dequeue()
        {
            try
            {
                T returnValue = data[0];

                numberOfElements--;

                T[] newData = new T[numberOfElements];

                for (int i = 0; i < numberOfElements; i++)
                    newData[i] = data[i + 1];

                data = newData;

                return returnValue;
            }
            catch(System.NullReferenceException)
            {
                throw new System.NullReferenceException("Queue empty.");
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
                throw new System.IndexOutOfRangeException("Queue empty.");
            }
            catch (System.NullReferenceException)
            {
                throw new System.NullReferenceException("Queue empty.");
            }
        }
    }
}
