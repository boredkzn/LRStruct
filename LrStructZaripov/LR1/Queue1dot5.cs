using System;

namespace LrStructZaripov.LR1
{
    public class Queue1dot5
    {
        private int[] queue;
        private int first;
        private int last;
        private int maxSize;
        private int currentSize;

        public Queue1dot5()
        {

        }

        public Queue1dot5(int size)
        {
            maxSize = size;
            queue = new int[maxSize];
            first = 0;
            last = -1;
            currentSize = 0;
        }

        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        public bool IsFull()
        {
            return currentSize == maxSize;
        }

        public void Enqueue(int item)
        {
            if (IsFull())
            {
                Console.WriteLine("Очередь заполнена. Невозможно добавить элемент.");
                return;
            }
            last = (last + 1) % maxSize;
            queue[last] = item;
            currentSize++;
            Console.WriteLine($"Элемент {item} добавлен в очередь.");
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Очередь пуста. Невозможно удалить элемент.");
                return -1;
            }
            int item = queue[first];
            first = (first + 1) % maxSize;
            currentSize--;
            return item;
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Очередь пуста.");
                return;
            }
            Console.WriteLine("Текущая очередь:");
            for (int i = 0; i < currentSize; i++)
            {
                Console.WriteLine(queue[(first + i) % maxSize]);
            }
        }


        public void MainQueue1dot5()
        {
            Console.WriteLine("Введите размер очереди:");
            int size = int.Parse(Console.ReadLine());
            Queue1dot5 queue = new Queue1dot5(size);

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить элемент в очередь");
                Console.WriteLine("2. Удалить элемент из очереди");
                Console.WriteLine("3. Показать состояние очереди");
                Console.WriteLine("4. Выход");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите элемент для добавления: ");
                            if (int.TryParse(Console.ReadLine(), out var item))
                            {
                                queue.Enqueue(item);
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное число.");
                            }
                            break;
                        case 2:
                            int removedItem = queue.Dequeue();
                            if (removedItem != -1)
                            {
                                Console.WriteLine($"Удален элемент: {removedItem}");
                            }
                            break;
                        case 3:
                            queue.Display();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите корректное целое число.");
                }
            }
        }
    }
}

