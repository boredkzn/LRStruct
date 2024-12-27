using System;

namespace LrStructZaripov.LR3
{
    public class Array3dot3
    {
        private ExternalNode externalHeader;

        public Array3dot3()
        {
            externalHeader = new ExternalNode(null);
        }

        public void DisplayAllLists()
        {
            if (IsEmpty(externalHeader))
            {
                Console.WriteLine("Список списков пуст!");
                return;
            }

            Console.WriteLine("Списки:");
            ExternalNode currentExternal = externalHeader.Next;
            while (currentExternal != null)
            {
                DisplayInternalList(currentExternal.InternalList);
                currentExternal = currentExternal.Next;
            }
        }

        public void DisplayInternalList(InternalNode internalHeader)
        {
            if (IsEmpty(internalHeader))
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            Console.WriteLine("Элементы списка:");
            InternalNode currentInternal = internalHeader;
            while (currentInternal != null)
            {
                Console.Write(currentInternal.Number + " ");
                currentInternal = currentInternal.Next;
            }
            Console.WriteLine();
        }

        public void AddNewList()
        {
            ExternalNode newList = new ExternalNode(null);
            if (IsEmpty(externalHeader))
            {
                externalHeader.Next = newList;
                Console.WriteLine("Создан новый список.");
            }
            else
            {
                ExternalNode current = externalHeader;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newList;
                Console.WriteLine("Создан новый список.");
            }
        }

        public void AddElementToList(int listIndex, int number)
        {
            ExternalNode externalCurrent = GetExternalNodeAt(listIndex);
            if (externalCurrent == null) return;

            InternalNode newElement = new InternalNode(number, null);
            if (IsEmpty(externalCurrent.InternalList))
            {
                externalCurrent.InternalList = newElement;
                Console.WriteLine($"Элемент '{number}' добавлен в список {listIndex}.");
            }
            else
            {
                InternalNode internalCurrent = externalCurrent.InternalList;
                while (internalCurrent.Next != null)
                {
                    internalCurrent = internalCurrent.Next;
                }
                internalCurrent.Next = newElement;
                Console.WriteLine($"Элемент '{number}' добавлен в список {listIndex}.");
            }
        }

        public void RemoveElementFromList(int listIndex, int number)
        {
            ExternalNode externalCurrent = GetExternalNodeAt(listIndex);
            if (externalCurrent == null) return;

            InternalNode currentInternal = externalCurrent.InternalList;
            InternalNode previousInternal = null;

            while (currentInternal != null)
            {
                if (currentInternal.Number == number)
                {
                    if (previousInternal == null)
                    {
                        externalCurrent.InternalList = currentInternal.Next;
                    }
                    else
                    {
                        previousInternal.Next = currentInternal.Next;
                    }
                    Console.WriteLine($"Элемент '{number}' удален из списка {listIndex}.");
                    return;
                }

                previousInternal = currentInternal;
                currentInternal = currentInternal.Next;
            }
            Console.WriteLine($"Элемент '{number}' не найден в списке {listIndex}.");
        }

        public void MainArray3dot3()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Вывести все списки");
                Console.WriteLine("2. Добавить новый список");
                Console.WriteLine("3. Добавить элемент в список");
                Console.WriteLine("4. Удалить элемент из списка");
                Console.WriteLine("5. Выход");

                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayAllLists();
                            break;
                        case 2:
                            AddNewList();
                            break;
                        case 3:
                            Console.Write("Введите номер списка для добавления элемента: ");
                            if (int.TryParse(Console.ReadLine(), out int listIndex) &&
                                listIndex > 0)
                            {
                                Console.Write("Введите значение элемента: ");
                                if (int.TryParse(Console.ReadLine(), out int number))
                                {
                                    AddElementToList(listIndex, number);
                                }
                                else
                                {
                                    Console.WriteLine("Введите корректное значение.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введите корректный номер списка.");
                            }
                            break;
                        case 4:
                            Console.Write("Введите номер списка для удаления элемента: ");
                            if (int.TryParse(Console.ReadLine(), out int removeIndex) &&
                                removeIndex > 0)
                            {
                                Console.Write("Введите значение элемента для удаления: ");
                                if (int.TryParse(Console.ReadLine(), out int removeValue))
                                {
                                    RemoveElementFromList(removeIndex, removeValue);
                                }
                                else
                                {
                                    Console.WriteLine("Введите корректное значение.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введите корректный номер списка.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Выход из программы.");
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите корректное целое число.");
                }
            }
        }

        private ExternalNode GetExternalNodeAt(int index)
        {
            ExternalNode current = externalHeader.Next;
            for (int i = 1; current != null && i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        private bool IsEmpty(ExternalNode list) => list == null;
        private bool IsEmpty(InternalNode list) => list == null;

        public class ExternalNode
        {
            public InternalNode InternalList;
            public ExternalNode Next;

            public ExternalNode(InternalNode internalList)
            {
                InternalList = internalList;
                Next = null;
            }
        }

        public class InternalNode
        {
            public int Number;
            public InternalNode Next;

            public InternalNode(int number, InternalNode next)
            {
                Number = number;
                Next = next;
            }
        }
    }
}
