namespace Queue
{
    class Queue <T>
    {
        private readonly static int MAX_SIZE = 1000;
        private readonly T[] data = new T [MAX_SIZE];
        private int numberOfElements = 0;

        public Queue()
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

        public void Enqueue(T value)
        {
            try
            {
                data[numberOfElements] = value;
                numberOfElements++;
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("Queue full.");
            }
        }

        public T Dequeue()
        {
            try
            {
                T first = data[0];

                for (int i = 0; i < numberOfElements; i++)
                    data[i] = data[i + 1];

                numberOfElements--;

                data[numberOfElements] = default;

                return first;
            }
            catch(System.IndexOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("Queue empty.");
            }
        }

        public T Peek()
        {
            try
            { 
                return data[0];
            }
            catch(System.IndexOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("Queue empty.");
            }
        }
    }
}
