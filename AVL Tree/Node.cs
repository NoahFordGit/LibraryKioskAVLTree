using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public Node(T data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }
    }
}
