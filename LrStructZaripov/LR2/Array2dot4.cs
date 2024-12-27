using System;

namespace LrStructZaripov.LR2
{
    public class Array2dot4
    {
        private Uzel header; 
        private Uzel current; 

        public Array2dot4()
        {
            header = new Uzel(int.MinValue); 
            current = null; 
        }

        public void Display()
        {
            if (current == null)
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            Console.WriteLine("Элементы списка:");
            Uzel temp = current;

            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        public void AddAfter(int afterValue, int newValue)
        {
            Uzel newUzel = new Uzel(newValue);

            if (current == null) 
            {
                current = newUzel;
                header.Next = current; 
                Console.WriteLine($"Элемент '{newValue}' добавлен в пустой список.");
                return;
            }

            Uzel temp = Find(afterValue);
            if (temp == null) return;

            newUzel.Next = temp.Next;
            temp.Next = newUzel;
            Console.WriteLine($"Элемент '{newValue}' добавлен после '{afterValue}'.");
        }

        public void AddBefore(int beforeValue, int newValue)
        {
            Uzel newUzel = new Uzel(newValue);

            if (current == null) 
            {
                current = newUzel;
                header.Next = current; 
                Console.WriteLine($"Элемент '{newValue}' добавлен в пустой список.");
                return;
            }
         
            if (current.Data == beforeValue)
            {
                newUzel.Next = current;
                header.Next = newUzel; 
                current = newUzel; 
                Console.WriteLine($"Элемент '{newValue}' добавлен перед '{beforeValue}'.");
                return;
            }

            Uzel temp = header.Next; 
            while (temp != null && temp.Next != null && temp.Next.Data != beforeValue)
            {
                temp = temp.Next;
            }

            if (temp != null && temp.Next != null)
            {
                newUzel.Next = temp.Next;
                temp.Next = newUzel;
                Console.WriteLine($"Элемент '{newValue}' добавлен перед '{beforeValue}'.");
            }
            else
            {
                Console.WriteLine($"Элемент '{beforeValue}' не найден.");
            }
        }

        public void Remove(int value)
        {
            if (current == null) return;

            if (current.Data == value)
            {
                current = current.Next; 
                header.Next = current; 
                Console.WriteLine($"Элемент '{value}' удален.");
                return;
            }

            Uzel temp = header; 
            while (temp.Next != null && temp.Next.Data != value)
            {
                temp = temp.Next;
            }

            if (temp.Next != null)
            {
                temp.Next = temp.Next.Next; 
                Console.WriteLine($"Элемент '{value}' удален.");
            }
            else
            {
                Console.WriteLine($"Элемент '{value}' не найден.");
            }
        }

        public Uzel Find(int value)
        {
            Uzel temp = current;
            while (temp != null)
            {
                if (temp.Data == value)
                {
                    Console.WriteLine($"Элемент '{value}' найден.");
                    return temp;
                }
                temp = temp.Next;
            }

            Console.WriteLine($"Элемент '{value}' не найден в списке.");
            return null;
        }

        public void MainArray2dot2()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Вывести элементы списка");
                Console.WriteLine("2. Найти элемент");
                Console.WriteLine("3. Добавить элемент после заданного");
                Console.WriteLine("4. Добавить элемент перед заданным");
                Console.WriteLine("5. Удалить элемент");
                Console.WriteLine("6. Выход");

                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Display();
                            break;
                        case 2:
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
                        case 3:
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
                        case 4:
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
                        case 5:
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
                        case 6:
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
