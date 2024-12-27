using System;

namespace LrStructZaripov.LR1
{
    public class Queue1dot6
    {
        private Uzel first;
        private Uzel last;

        public Queue1dot6()
        {
            first = null;
            last = null;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Enqueue(int item)
        {
            Uzel newUzel = new Uzel(item);
            if (IsEmpty())
            {
                first = newUzel;
                last = newUzel;
                last.Next = first;
            }
            else
            {
                last.Next = newUzel;
                last = newUzel;
                last.Next = first;
            }
            Console.WriteLine($"Элемент {item} добавлен в очередь.");
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Очередь пуста. Невозможно удалить элемент.");
                return -1;
            }

            int item = first.Data;
            if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                first = first.Next;
                last.Next = first;
            }
            Console.WriteLine($"Удален элемент: {item}");
            return item;
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Очередь пуста.");
                return;
            }
            Uzel temp = first;
            Console.WriteLine("Текущая очередь:");
            do
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            } while (temp != first);
        }



        public void MainQueue1dot6()
        {
            Queue1dot6 queue = new Queue1dot6();
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
                            queue.Dequeue();
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

