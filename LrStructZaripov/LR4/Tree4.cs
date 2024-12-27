using System;

namespace LrStructZaripov.LR4
{
    public class Tree4
    {
        private Random random = new Random();

        public void MainTree4()
        {
            Console.WriteLine("Введите количество вершин дерева: ");
            if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
            {
                TreeNode root = CreateTree(count);
                Console.WriteLine("\nДерево в прямом порядке:");
                Straight(root, 0);
                Console.WriteLine("\nДерево в симметричном порядке:");
                Simmetrical(root, 0);
                Console.WriteLine("\nДерево в обратно-симметричном порядке:");
                Reverse(root, 0);
            }
            else
            {
                Console.WriteLine("Ошибка: значение не является положительным числом.");
            }
        }

        private TreeNode CreateTree(int count)
        {
            if (count <= 0) return null;
            TreeNode node = new TreeNode(random.Next(0, 100));

            node.First = CreateTree(count - 1);
            node.Second = CreateTree(count - 1);

            return node;
        }

        private void Straight(TreeNode node, int level)
        {
            if (node == null) return;

            Console.WriteLine($"{new string('\t', level)}{node.Num}");
            Straight(node.First, level + 1);
            Straight(node.Second, level + 1);
        }

        private void Simmetrical(TreeNode node, int level)
        {
            if (node == null) return;

            Simmetrical(node.First, level + 1);
            Console.WriteLine($"{new string('\t', level)}{node.Num}");
            Simmetrical(node.Second, level + 1);
        }

        private void Reverse(TreeNode node, int level)
        {
            if (node == null) return;

            Reverse(node.Second, level + 1);
            Console.WriteLine($"{new string('\t', level)}{node.Num}");
            Reverse(node.First, level + 1);
        }

        public class TreeNode
        {
            public int Num { get; }
            public TreeNode? First { get; set; }
            public TreeNode? Second { get; set; }

            public TreeNode(int num)
            {
                Num = num;
                First = null;
                Second = null;
            }
        }
    }
}
