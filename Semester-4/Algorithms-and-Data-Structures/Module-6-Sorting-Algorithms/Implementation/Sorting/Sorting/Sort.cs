namespace Sorting
{
    using System;
    static class Sort
    {
        static Random r = new Random();

        public static void InsertionSort(decimal[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                decimal key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j -= 1;
                }
                array[j + 1] = key;
            }
        }

        public static void BubbleSort(decimal[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        decimal temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
        }

        public static void QuickSort(decimal[] array, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = array[(left + right) / 2];
            while (i < j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    var tmp = array[i];
                    array[i++] = array[j];
                    array[j--] = tmp;
                }
            }
            if (left < j) QuickSort(array, left, j);
            if (i < right) QuickSort(array, i, right);
        }

        public static void HeapSort(decimal[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                decimal temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        public static void MergeSort(decimal[] array, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(array, l, m);
                MergeSort(array, m + 1, r);

                Merge(array, l, m, r);
            }
        }


        static void Heapify(decimal[] array, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && array[l] > array[largest])
                largest = l;

            if (r < n && array[r] > array[largest])
                largest = r;

            if (largest != i)
            {
                decimal swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Heapify(array, n, largest);
            }
        }

        static void Merge(decimal[] aray, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            decimal[] L = new decimal [n1];
            decimal[] R = new decimal [n2];


            for (i = 0; i < n1; i++)
                L[i] = aray[l + i];
            for (j = 0; j < n2; j++)
                R[j] = aray[m + 1 + j];

            i = 0;
            j = 0;
            k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    aray[k] = L[i];
                    i++;
                }
                else
                {
                    aray[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                aray[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                aray[k] = R[j];
                j++;
                k++;
            }
        }

        public static void Shuffle(decimal[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = r.Next(0, i + 1);

                decimal temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
