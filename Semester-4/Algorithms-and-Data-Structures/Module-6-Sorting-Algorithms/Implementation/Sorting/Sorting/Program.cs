namespace Sorting
{
    using System;
    class Program
    {
        static void Main()
        {
            decimal[] array = { 0, 12, 34, 6, 1, 23, -1, 24 };

            DisplayArray(array);

            Sort.InsertionSort(array);

            DisplayArray(array);

            Sort.Shuffle(array);


            DisplayArray(array);

            Sort.BubbleSort(array);

            DisplayArray(array);

            Sort.Shuffle(array);


            DisplayArray(array);

            Sort.QuickSort(array, 0, array.Length - 1);

            DisplayArray(array);

            Sort.Shuffle(array);


            DisplayArray(array);

            Sort.HeapSort(array);

            DisplayArray(array);

            Sort.Shuffle(array);


            DisplayArray(array);

            Sort.MergeSort(array, 0, array.Length - 1);

            DisplayArray(array);

            Sort.Shuffle(array);


            Console.ReadKey();
        }

        static void DisplayArray(decimal[] array)
        {
            foreach (var item in array)
                Console.Write($"{item} ");
            Console.WriteLine('\n');
        }
    }
}
