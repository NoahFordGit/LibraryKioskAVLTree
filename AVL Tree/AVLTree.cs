using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.AVL_Tree
{
    internal class AVLTree
    {
        private Node? _root;
        private Comparison<Book> _compare; // chatgpt, sorting rules must be defined on instantiation

        public AVLTree(Comparison<Book> comparison)
        {
            _compare = comparison;
        }

        private int Height(Node? node)
        {
            return node?.Height ?? 0; // return node height or 0 if null -- chatgpt
        }

        private void UpdateHeight(Node node)
        {
            node.Height = 1 + Math.Max(Height(node.Right), Height(node.Left));
        }

        private int GetBalance(Node node)
        {
            int balance = Height(node.Left) - Height(node.Right);
            return balance;
        }

        private Node RightRotate(Node y)
        {
            Node x = y.Left!;
            Node xr = x.Right!;

            x.Right = y;
            y.Left = xr;

            UpdateHeight(x);
            UpdateHeight(y);

            return x;
        }

        private Node LeftRotate(Node y)
        {
            Node x = y.Right!;
            Node xl = x.Left!;

            x.Left = y;
            y.Right = xl;

            UpdateHeight(x);
            UpdateHeight(y);

            return x;
        }

        public void Insert(Book book)
        {
            _root = Insert(_root, book);
        }

        private Node Insert(Node? node, Book book)
        {
            if (node == null)
                return new Node(book);

            if (_compare(book, node.Data) < 0)
                node.Left = Insert(node.Left, book);

            else if (_compare(book, node.Data) > 0)
                node.Right = Insert(node.Right, book);

            else
                return node;

            UpdateHeight(node);

            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (_compare(book, node.Data) < 0)
                    return RightRotate(node);
                else
                {
                    node.Left = LeftRotate(node.Left!);
                    return RightRotate(node);
                }
            }    

            if (balance < -1)
            {
                if (_compare(book, node.Data) > 0)
                    return LeftRotate(node);
                else
                {
                    node.Right = RightRotate(node.Right!);
                    return LeftRotate(node);
                }
            }

            return node;
        }

        public void Remove(Node node)
        {

        }


        public void InOrder()
        {
            InOrder(_root);
        }

        private void InOrder(Node? node)
        {
            if (node == null) return;

            InOrder(node.Left);
            node.Data.Print();
            InOrder(node.Right);
        }
        public void PrintTree()
        {
            PrintTree(_root, 0);
        }

        private void PrintTree(Node? node, int indent)
        {
            if (node == null) return;

            PrintTree(node.Right, indent + 4);

            Console.WriteLine(new string(' ', indent) + node.Data.Title);

            PrintTree(node.Left, indent + 4);
        }
    }
}
