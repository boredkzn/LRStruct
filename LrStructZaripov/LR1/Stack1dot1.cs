namespace LrStructZaripov.LR1
{
    public class Stack1dot1
    {
        private int[] array;
        private int top;
        private int maxSize;

        public Stack1dot1()
        {

        }

        public Stack1dot1(int size)
        {
            maxSize = size;
            array = new int[maxSize];
            top = -1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == maxSize - 1;
        }

        public void Push(int item)
        {
            if (IsFull())
            {
                Console.WriteLine("Стек заполнен. Невозможно добавить элемент.");
                return;
            }
            array[++top] = item;
            Console.WriteLine($"Элемент {item} добавлен в стек.");
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст. Невозможно удалить элемент.");
                return -1;
            }
            return array[top--];
        }


        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст.");
                return;
            }
            Console.WriteLine("Текущий стек:");
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }

        public void MainStack1dot1()
        {
            Console.Write("Введите размер стека: ");
            int size = int.Parse(Console.ReadLine());
            Stack1dot1 stack = new Stack1dot1(size);

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
                            stack.Push(item);
                            break;
                        case 2:
                            int poppedItem = stack.Pop();
                            if (poppedItem != -1)
                            {
                                Console.WriteLine($"Удален элемент: {poppedItem}");
                            }
                            break;
                        case 3:
                            stack.Display();
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

