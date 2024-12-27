using System;

namespace LrStructZaripov.LR6
{
    public class SortMethodsBetter
    {
        public SortMethodsBetter() { }

        public void MainSortMethodsBetter()
        {
            int[] array;

            Console.Write("Введите количество элементов в массиве (не более 10000): ");
            int numElements = int.Parse(Console.ReadLine());
            array = GenerateRandomArray(numElements);

            while (true)
            {
                Console.WriteLine("Выберите метод сортировки:");
                Console.WriteLine("1 - Сортировка пузырьком");
                Console.WriteLine("2 - Сортировка выбором");
                Console.WriteLine("3 - Сортировка вставками");
                Console.WriteLine("4 - Быстрая сортировка");
                Console.WriteLine("5 - Сортировка слиянием");
                Console.WriteLine("6 - Сортировка Шелла");
                Console.WriteLine("7 - Выход");
                Console.Write("Ваш выбор: ");

                int[] arrayCopy = (int[])array.Clone(); // создаем копию массива

                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            BubbleSort(arrayCopy);
                            break;
                        case 2:
                            SelectionSort(arrayCopy);
                            break;
                        case 3:
                            InsertionSort(arrayCopy);
                            break;
                        case 4:
                            int quickComparisons = 0;
                            int quickSwaps = 0;
                            QuickSort(arrayCopy, 0, arrayCopy.Length - 1, ref quickComparisons, ref quickSwaps);
                            Console.WriteLine($"Быстрая сортировка: Сравнения = {quickComparisons}, Перестановки = {quickSwaps}");
                            break;
                        case 5:
                            int mergeComparisons = 0;
                            int mergeSwaps = 0;
                            MergeSort(arrayCopy, 0, arrayCopy.Length - 1, ref mergeComparisons, ref mergeSwaps);
                            Console.WriteLine($"Сортировка слиянием: Сравнения = {mergeComparisons}, Перестановки = {mergeSwaps}");
                            break;
                        case 6:
                            ShellSort(arrayCopy);
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите корректное целое число.");
                }

                Console.WriteLine("Отсортированный массив: " + string.Join(", ", arrayCopy));
                Console.WriteLine();
            }
        }

        public int[] GenerateRandomArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(1, 10001);
            }
            Console.WriteLine("Сгенерированный массив: " + string.Join(", ", array));
            return array;
        }

        public void BubbleSort(int[] array)
        {
            int comparisons = 0;
            int swaps = 0;
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisons++;
                    if (array[j] > array[j + 1])
                    {
                        swaps++;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine($"Пузырьковая сортировка: Сравнения = {comparisons}, Перестановки = {swaps}");
        }

        public void SelectionSort(int[] array)
        {
            int comparisons = 0;
            int swaps = 0;
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    comparisons++;
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    swaps++;
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }

            Console.WriteLine($"Сортировка выбором: Сравнения = {comparisons}, Перестановки = {swaps}");
        }

        public void InsertionSort(int[] array)
        {
            int comparisons = 0;
            int swaps = 0;
            int n = array.Length;

            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    comparisons++;
                    swaps++;
                    array[j + 1] = array[j];
                    j--;
                }
                comparisons++;
                array[j + 1] = key;
            }

            Console.WriteLine($"Сортировка вставками: Сравнения = {comparisons}, Перестановки = {swaps}");
        }

        public void QuickSort(int[] array, int low, int high, ref int comparisons, ref int swaps)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high, ref comparisons, ref swaps);
                QuickSort(array, low, pi - 1, ref comparisons, ref swaps);
                QuickSort(array, pi + 1, high, ref comparisons, ref swaps);
            }
        }

        private int Partition(int[] array, int low, int high, ref int comparisons, ref int swaps)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                comparisons++;
                if (array[j] < pivot)
                {
                    i++;
                    swaps++;
                    Swap(array, i, j);
                }
            }
            swaps++;
            Swap(array, i + 1, high);
            return i + 1;
        }

        public void MergeSort(int[] array, int left, int right, ref int comparisons, ref int swaps)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid, ref comparisons, ref swaps);
                MergeSort(array, mid + 1, right, ref comparisons, ref swaps);
                Merge(array, left, mid, right, ref comparisons, ref swaps);
            }
        }

        private void Merge(int[] array, int left, int mid, int right, ref int comparisons, ref int swaps)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
                L[i] = array[left + i];
            for (int j = 0; j < n2; j++)
                R[j] = array[mid + 1 + j];

            int k = left;
            int iIndex = 0;
            int jIndex = 0;

            while (iIndex < n1 && jIndex < n2)
            {
                comparisons++;
                if (L[iIndex] <= R[jIndex])
                {
                    array[k] = L[iIndex];
                    iIndex++;
                }
                else
                {
                    array[k] = R[jIndex];
                    jIndex++;
                    swaps++;
                }
                k++;
            }

            while (iIndex < n1)
            {
                array[k] = L[iIndex];
                iIndex++;
                k++;
            }

            while (jIndex < n2)
            {
                array[k] = R[jIndex];
                jIndex++;
                k++;
            }
        }

        public void ShellSort(int[] array)
        {
            int comparisons = 0;
            int swaps = 0;
            int n = array.Length;
            int[] gaps = { 701, 301, 132, 57, 23, 10, 4, 1 };

            foreach (int gap in gaps)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    comparisons++;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        comparisons++;
                        swaps++;
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }

            Console.WriteLine($"Сортировка Шелла: Сравнения = {comparisons}, Перестановки = {swaps}");
        }

        private void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
