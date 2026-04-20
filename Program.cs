using Project4.AVL_Tree;

namespace Project4
{
    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;
    using Project4.AVL_Tree;

    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\noahm\\OneDrive - East Tennessee State University\\CSCI 2210\\projects\\Project4\\Data\\books.csv";

            // Create AVL Trees with different sorting rules
            AVLTree titleTree = new AVLTree(
                (a, b) => string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase)
            );

            AVLTree authorTree = new AVLTree(
                (a, b) => string.Compare(a.Author, b.Author, StringComparison.OrdinalIgnoreCase)
            );

            // Load books from CSV
            List<Book> books = LoadBooks(path);

            // Insert into both trees
            foreach (var book in books)
            {
                titleTree.Insert(book);
                authorTree.Insert(book);
            }

            // Display trees
            Console.WriteLine("=== Books Sorted by Title ===\n");
            titleTree.InOrder();

            Console.WriteLine("\n=== Books Sorted by Author ===\n");
            authorTree.InOrder();

            // Test insertion after load
            Console.WriteLine("\n=== Adding Test Book ===\n");
            Book testBook = new Book("Z Test Book", "Tester, John", 123, "TestPub");

            titleTree.Insert(testBook);
            authorTree.Insert(testBook);

            Console.WriteLine("=== After Insert (Title Order) ===\n");
            titleTree.InOrder();
        }

        static List<Book> LoadBooks(string path)
        {
            List<Book> books = new List<Book>();

            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                // Skip header
                if (!parser.EndOfData)
                    parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[]? fields = parser.ReadFields();

                    if (fields == null || fields.Length < 4)
                        continue;

                    string title = fields[0].Trim();
                    string author = fields[1].Trim();

                    if (!int.TryParse(fields[2], out int pages))
                        continue;

                    string publisher = fields[3].Trim();

                    books.Add(new Book(title, author, pages, publisher));
                }
            }

            return books;
        }
    }
}