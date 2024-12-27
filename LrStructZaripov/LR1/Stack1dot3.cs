using System;

namespace LrStructZaripov.LR1
{

    public class Stack1dot3
    {
        private Uzel top;

        public Stack1dot3()
        {
            top = null;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public void Push(int item)
        {
            Uzel newUzel = new Uzel(item);
            newUzel.Next = top;
            top = newUzel;
            Console.WriteLine($"Элемент {item} добавлен в стек.");
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст. Невозможно удалить элемент.");
                return -1;
            }
            int poppedItem = top.Data;
            top = top.Next;
            return poppedItem;
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст.");
                return;
            }
            Console.WriteLine("Текущий стек:");
            Uzel current = top;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void MainStack1dot3()
        {
            Console.WriteLine("Работа с динамическим стеком:");
            Random random = new Random();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Показать состояние стека");
                Console.WriteLine("4. Добавить несколько случайных элементов");
                Console.WriteLine("5. Выход");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите элемент, который хотите добавить: ");
                            int item = int.Parse(Console.ReadLine());
                            Push(item);
                            break;
                        case 2:
                            int poppedItem = Pop();
                            if (poppedItem != -1)
                            {
                                Console.WriteLine($"Удален элемент: {poppedItem}");
                            }
                            break;
                        case 3:
                            Display();
                            break;
                        case 4:
                            Console.Write("Введите количество элементов, которые хотите добавить: ");
                            if (int.TryParse(Console.ReadLine(), out var count) && count > 0)
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    int randomValue = random.Next(1, 101);
                                    Push(randomValue);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное положительное число.");
                            }
                            break;
                        case 5:
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
