using System;

namespace LrStructZaripov.LR2
{
    public class Array2dot1
    {
        private int[] elements; 
        private int count;
        private int size;

        public Array2dot1()
        {

        }

        public Array2dot1(int size)
        {
            this.size = size;
            elements = new int[size]; 
            count = 0;
        }

        public void Display()
        {
            if (count == 0)
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            Console.WriteLine("Элементы списка:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(elements[i]);
            }
        }

        public int Find(int value) 
        {
            for (int i = 0; i < count; i++)
            {
                if (elements[i] == value)
                {
                    Console.WriteLine($"Элемент '{value}' найден на позиции {i}.");
                    return i;
                }
            }

            Console.WriteLine($"Элемент '{value}' не найден в списке.");
            return -1;
        }

        public void AddAfter(int afterValue, int newValue) 
        {
            if (count >= size)
            {
                Console.WriteLine("Нет свободных ячеек для добавления нового элемента.");
                return;
            }

            int index = Find(afterValue);
            if (index == -1)
                return;

            for (int i = count; i > index + 1; i--)
            {
                elements[i] = elements[i - 1];
            }

            elements[index + 1] = newValue;
            count++;
            Console.WriteLine($"Элемент '{newValue}' добавлен после '{afterValue}'.");
        }

        public void AddBefore(int beforeValue, int newValue) 
        {
            if (count >= size)
            {
                Console.WriteLine("Нет свободных ячеек для добавления нового элемента.");
                return;
            }

            int index = Find(beforeValue);
            if (index == -1)
                return;

            for (int i = count; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }

            elements[index] = newValue;
            count++;
            Console.WriteLine($"Элемент '{newValue}' добавлен перед '{beforeValue}'.");
        }

        public void Remove(int value) 
        {
            int index = Find(value);
            if (index == -1)
                return;

            for (int i = index; i < count - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            elements[count - 1] = 0; 
            count--;
            Console.WriteLine($"Элемент '{value}' удален.");
        }

        public void Add(int newValue) 
        {
            if (count >= size)
            {
                Console.WriteLine("Нет свободных ячеек для добавления нового элемента.");
                return;
            }

            elements[count] = newValue;
            count++;
            Console.WriteLine($"Элемент '{newValue}' добавлен в список.");
        }

        public void MainArray2dot1()
        {
            int maxSize = 10; 
            Array2dot1 arr = new Array2dot1(maxSize);

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Вывести элементы списка");
                Console.WriteLine("2. Найти элемент");
                Console.WriteLine("3. Добавить элемент после заданного");
                Console.WriteLine("4. Добавить элемент перед заданным");
                Console.WriteLine("5. Удалить элемент");
                Console.WriteLine("6. Добавить элемент");
                Console.WriteLine("7. Выход");

                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            arr.Display();
                            break;
                        case 2:
                            Console.Write("Введите значение для поиска: ");
                            if (int.TryParse(Console.ReadLine(), out int searchValue))
                            {
                                arr.Find(searchValue);
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное целое число.");
                            }
                            break;
                        case 3:
                            Console.Write("Введите элемент после которого нужно добавить: ");
                            if (int.TryParse(Console.ReadLine(), out int afterValue))
                            {
                                Console.Write("Введите значение нового элемента: ");
                                if (int.TryParse(Console.ReadLine(), out int newValueAfter))
                                {
                                    arr.AddAfter(afterValue, newValueAfter);
                                }
                                else
                                {
                                    Console.WriteLine("Пожалуйста, введите корректное целое число.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное целое число.");
                            }
                            break;
                        case 4:
                            Console.Write("Введите элемент перед которым нужно добавить: ");
                            if (int.TryParse(Console.ReadLine(), out int beforeValue))
                            {
                                Console.Write("Введите значение нового элемента: ");
                                if (int.TryParse(Console.ReadLine(), out int newValueBefore))
                                {
                                    arr.AddBefore(beforeValue, newValueBefore);
                                }
                                else
                                {
                                    Console.WriteLine("Пожалуйста, введите корректное целое число.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное целое число.");
                            }
                            break;
                        case 5:
                            Console.Write("Введите значение элемента для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int removeValue))
                            {
                                arr.Remove(removeValue);
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное целое число.");
                            }
                            break;
                        case 6:
                            Console.Write("Введите значение нового элемента для добавления в список: ");
                            if (int.TryParse(Console.ReadLine(), out int newValue))
                            {
                                arr.Add(newValue);
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное целое число.");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Выход из программы.");
                            return;
                        default:
                            Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте еще раз.");
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
