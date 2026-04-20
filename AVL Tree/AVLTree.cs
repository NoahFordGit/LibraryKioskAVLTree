using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.AVL_Tree
{
    internal class AVLTree
    {
        public Node Head { get; set; }
        public AVLTree(Node head) { Head = head; }

        private int Height(Node? node)
        {
            return node?.Height ?? 0; // return node height or 0 if null -- chatgpt
        }

        private int FindHeight(Node? node)
        {
            if (node == null) return -1;
            int height = 1 + Math.Max(Height(node.Right), Height(node.Left));

            return height;
        }

        private int FindBalance(Node node)
        {
            int balance = Math.Abs(Height(node.Left) - Height(node.Right));
            return balance;
        }

        private Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node xr = x.Right;

            x.Right = y;
            y.Left = xr;

            x.Height = FindHeight(x);
            y.Height = FindHeight(y);

            return x;
        }

        private Node LeftRotate(Node y)
        {
            Node x = y.Right;
            Node xl = x.Left;

            x.Left = y;
            y.Right = xl;

            x.Height = FindHeight(x);
            y.Height = FindHeight(y);

            return x;
        }

        public Node Insert(Node node)
        {

        }

        public void Remove(Node node)
        {

        }
    }
}
