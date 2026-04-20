using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.AVL_Tree
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; } // subpar representation of booklength imo
        public string Publisher { get; set; }

        public Book(string title, string author, int pages, string publisher)
        {
            Title = title;
            Author = author;
            Pages = pages;
            Publisher = publisher;
        }

        // i wouldve returned a string here but project specs say "DISPLAY" so we writelining it
        // also wouldve used ToString but it specificies "Print()"
        public void Print()
        {
            Console.WriteLine(
                $"Title: {Title}\n" +
                $"Author: {Author}\n" +
                $"Pages: {Pages}\n" +
                $"Publisher: {Publisher}\n"
            );
        }
    }
}
