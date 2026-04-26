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
            Node? xr = x.Right;

            x.Right = y;
            y.Left = xr;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private Node LeftRotate(Node y)
        {
            Node x = y.Right!;
            Node? xl = x.Left;

            x.Left = y;
            y.Right = xl;

            UpdateHeight(y);
            UpdateHeight(x);

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
                if (_compare(book, node.Left!.Data) < 0)
                    return RightRotate(node);
                else
                {
                    node.Left = LeftRotate(node.Left!);
                    return RightRotate(node);
                }
            }    

            if (balance < -1)
            {
                if (_compare(book, node.Right!.Data) > 0)
                    return LeftRotate(node);
                else
                {
                    node.Right = RightRotate(node.Right!);
                    return LeftRotate(node);
                }
            }

            return node;
        }

        public void Remove(Book book)
        {
            _root = Remove(_root, book);
        }

        private Node? Remove(Node? node, Book book)
        {
            if (node == null)
                return null;

            if (_compare(book, node.Data) < 0)
                node.Left = Remove(node.Left, book);

            else if (_compare(book, node.Data) > 0)
                node.Right = Remove(node.Right, book);

            else
            {
                // one or no child
                if (node.Left == null || node.Right == null)
                {
                    Node? temp = node.Left ?? node.Right;

                    if (temp == null)
                        return null;
                    else
                        return temp;
                }
                else
                {
                    Node temp = GetMinValueNode(node.Right);
                    node.Data = temp.Data;
                    node.Right = Remove(node.Right, temp.Data);
                }
            }

            UpdateHeight(node);

            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (GetBalance(node.Left!) >= 0)
                    return RightRotate(node);
                else
                {
                    node.Left = LeftRotate(node.Left!);
                    return RightRotate(node);
                }
            }

            if (balance < -1)
            {
                if (GetBalance(node.Right!) <= 0)
                    return LeftRotate(node);
                else
                {
                    node.Right = RightRotate(node.Right!);
                    return LeftRotate(node);
                }
            }

            return node;
        }

        private Node GetMinValueNode(Node node)
        {
            Node current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
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
            PrintTree(_root, "", true);
        }

        private void PrintTree(Node? node, string prefix, bool isLast)
        {
            if (node == null) return;

            Console.Write(prefix);

            Console.Write(isLast ? "└── " : "├── ");

            Console.WriteLine(FormatNode(node));

            string childPrefix = prefix + (isLast ? "    " : "│   ");

            bool hasLeft = node.Left != null;
            bool hasRight = node.Right != null;

            if (hasLeft || hasRight)
            {
                // print right first so tree leans left nicely
                if (node.Right != null)
                    PrintTree(node.Right, childPrefix, node.Left == null);

                if (node.Left != null)
                    PrintTree(node.Left, childPrefix, true);
            }
        }

        private string FormatNode(Node node)
        {
            string title = node.Data.Title;

            // shorten long titles so tree stays readable
            if (title.Length > 30)
                title = title.Substring(0, 30) + "...";

            return $"{title} (H:{node.Height}, B:{GetBalance(node)})";
        }
    }
}
