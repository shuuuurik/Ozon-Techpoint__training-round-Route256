using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Дерево_комментариев
{
    public class Node
    {
        public int Id { get; private set; }
        public int ParentId { get; private set; }
        public string Value { get; private set; }

        public Node(int id, int parentId, string value)
        {
            this.Id = id;
            this.ParentId = parentId;
            this.Value = value;
        }
    }

    public class Trees
    {
        public List<Node> nodes = new List<Node>();
        public void PrintTrees()
        {
            List<Node> roots = new List<Node>();
            foreach (Node node in nodes)
            {
                if (node.ParentId == -1)
                    roots.Add(node);
            }

            bool flag = false; // Для пустой строки между деревьями
            foreach (Node node in roots.OrderBy(i => i.Id))
            {
                if (flag)
                    Console.WriteLine();
                else
                    flag = true;
                Console.WriteLine(node.Value);
                PrintTree(node, "|");
            }
        }

        private void PrintTree(Node root, string offset)
        {
            List<Node> children = nodes.FindAll(x => x.ParentId == root.Id);
            int count = children.Count;
            int counter = 0;
            foreach (Node child in children.OrderBy(i => i.Id))
            {
                Console.WriteLine(offset);
                Console.WriteLine(offset + "--" + child.Value);
                if (++counter != count)
                    PrintTree(child, offset + "  |");
                else
                    PrintTree(child, offset[..^1] + "   |"); // У детей последнего сына убирается вертикальная черта
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Чтение и запись в файл
            //string srcpath = @"D:\university\Ozon Techpoint\3";
            //using (StreamReader reader = new StreamReader(srcpath))
            //{
            //}

            //string destpath = @"D:\university\Ozon Techpoint\out.txt";
            //using (StreamWriter writer = new StreamWriter(destpath))
            //{
            //}
            #endregion Чтение и запись в файл
            int t = int.Parse(Console.ReadLine());
            for (int k = 0; k < t; ++k)
            {
                int n = int.Parse(Console.ReadLine());
                Trees trees = new Trees();
                for (int i = 0; i < n; ++i)
                {
                    string node = Console.ReadLine();
                    int id = int.Parse(node.Substring(0, node.IndexOf(' ')));
                    node = node.Substring(node.IndexOf(' ') + 1);
                    int parentId = int.Parse(node.Substring(0, node.IndexOf(' ')));
                    string value = node.Substring(node.IndexOf(' ') + 1);

                    trees.nodes.Add(new Node(id, parentId, value));
                }

                trees.PrintTrees();

                if (k != t - 1) // пустая строка между наборами входных данных
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
