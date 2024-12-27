using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LrStructZaripov.LR1
{

    public class Stack1dot2
    {
        private Uzel top;

        public Stack1dot2()
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

        public void MainStack1dot2()
        {
            Console.WriteLine("Работа с динамическим стеком:");

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Показать состояние стека");
                Console.WriteLine("4. Выход");
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


