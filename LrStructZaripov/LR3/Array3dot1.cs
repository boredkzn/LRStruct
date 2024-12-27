using System;

namespace LrStructZaripov.LR3
{
    public class Array3dot1
    {
        private Uzel header;

        public Array3dot1()
        {
            header = new Uzel(int.MinValue); 
        }

        public void DisplayForward()
        {
            if (header.Next == header) 
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            Console.WriteLine("Элементы списка (вперед):");
            Uzel current = header.Next; 
            while (current != header)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void DisplayBackward()
        {
            if (header.Next == header) 
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            Console.WriteLine("Элементы списка (назад):");
            Uzel current = header.Prev; 
            while (current != header)
            {
                Console.WriteLine(current.Data);
                current = current.Prev;
            }
        }

        public void AddAfter(int afterValue, int newValue)
        {
            Uzel newUzel = new Uzel(newValue);
            Uzel current = Find(afterValue);
            if (current == null)
            {
                header.Next = newUzel;
                header.Prev = newUzel;
                newUzel.Next = header;
                newUzel.Prev = header;
                Console.WriteLine($"Элемент '{newValue}' добавлен в пустой список.");
                return;
            }

            newUzel.Next = current.Next;
            newUzel.Prev = current;

            current.Next.Prev = newUzel; 
            current.Next = newUzel;
            Console.WriteLine($"Элемент '{newValue}' добавлен после '{afterValue}'.");
        }

        public void AddBefore(int beforeValue, int newValue)
        {
            Uzel newUzel = new Uzel(newValue);
            Uzel current = Find(beforeValue);
            if (current == null)
            {
                header.Next = newUzel;
                header.Prev = newUzel;
                newUzel.Next = header;
                newUzel.Prev = header;

                Console.WriteLine($"Элемент '{newValue}' добавлен в пустой список.");
                return;
            }

            newUzel.Next = current;
            newUzel.Prev = current.Prev;

            current.Prev.Next = newUzel; 
            current.Prev = newUzel; 
            Console.WriteLine($"Элемент '{newValue}' добавлен перед '{beforeValue}'.");
        }

        public void Remove(int value)
        {
            Uzel current = Find(value);
            if (current == null)
            {
                Console.WriteLine($"Элемент '{value}' не найден.");
                return;
            }

            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev; 
            Console.WriteLine($"Элемент '{value}' удален.");
            
            if (current == header.Next)
                header.Next = current.Next;
        }

        public Uzel Find(int value)
        {
            Uzel current = header.Next;
            while (current != header)
            {
                if (current.Data == value)
                {
                    Console.WriteLine($"Элемент '{value}' найден.");
                    return current;
                }
                current = current.Next;
            }

            Console.WriteLine($"Элемент '{value}' не найден в списке.");
            return null;
        }

        public void MainArray3dot1()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Вывести элементы списка (вперед)");
                Console.WriteLine("2. Вывести элементы списка (назад)");
                Console.WriteLine("3. Найти элемент");
                Console.WriteLine("4. Добавить элемент после заданного");
                Console.WriteLine("5. Добавить элемент перед заданным");
                Console.WriteLine("6. Удалить элемент");
                Console.WriteLine("7. Выход");

                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayForward();
                            break;
                        case 2:
                            DisplayBackward();
                            break;
                        case 3:
                            Console.Write("Введите значение для поиска: ");
                            if (int.TryParse(Console.ReadLine(), out int searchValue))
                            {
                                Find(searchValue);
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста, введите корректное целое число.");
                            }
                            break;
                        case 4:
                            Console.Write("Введите элемент после которого нужно добавить: ");
                            if (int.TryParse(Console.ReadLine(), out int afterValue))
                            {
                                Console.Write("Введите значение нового элемента: ");
                                if (int.TryParse(Console.ReadLine(), out int newValueAfter))
                                {
                                    AddAfter(afterValue, newValueAfter);
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
                            Console.Write("Введите элемент перед которым нужно добавить: ");
                            if (int.TryParse(Console.ReadLine(), out int beforeValue))
                            {
                                Console.Write("Введите значение нового элемента: ");
                                if (int.TryParse(Console.ReadLine(), out int newValueBefore))
                                {
                                    AddBefore(beforeValue, newValueBefore);
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
                        case 6:
                            Console.Write("Введите значение элемента для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int removeValue))
                            {
                                Remove(removeValue);
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
