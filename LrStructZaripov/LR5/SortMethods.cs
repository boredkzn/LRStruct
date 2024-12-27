using System;

namespace LrStructZaripov.LR5
{
    public class SortMethods
    {
        public SortMethods() { }

        public void MainSortMethods()
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
                Console.WriteLine("4 - Выход");
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

            Console.WriteLine($"Пузырьковая сортировка : Сравнения = {comparisons}, Перестановки = {swaps}");
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
    }
}
