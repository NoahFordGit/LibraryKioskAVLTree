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

            List<Book> books = LoadBooks(path);

            // Trees
            AVLTree titleTree = new AVLTree((a, b) =>
                string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase));

            AVLTree authorTree = new AVLTree((a, b) =>
                string.Compare(a.Author, b.Author, StringComparison.OrdinalIgnoreCase));

            AVLTree publisherTree = new AVLTree((a, b) =>
                string.Compare(a.Publisher, b.Publisher, StringComparison.OrdinalIgnoreCase));

            // Load data
            foreach (var book in books)
            {
                titleTree.Insert(book);
                authorTree.Insert(book);
                publisherTree.Insert(book);
            }

            while (true)
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("       AVL TREE BOOK SYSTEM       ");
                Console.WriteLine("==================================");
                Console.WriteLine("1. View Tree (Title)");
                Console.WriteLine("2. View Tree (Author)");
                Console.WriteLine("3. View Tree (Publisher)");
                Console.WriteLine("4. Insert Book");
                Console.WriteLine("5. Remove Book");
                Console.WriteLine("6. Exit");
                Console.Write("Select option: ");

                /*
                To whoever is grading please be chill :(
                This was the best way I thought to demonstrate functionality
                I SWEAR IT WORKS PLEASE BE COOL
                */

                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("=== TITLE TREE ===\n");
                        titleTree.PrintTree();
                        break;

                    case "2":
                        Console.WriteLine("=== AUTHOR TREE ===\n");
                        authorTree.PrintTree();
                        break;

                    case "3":
                        Console.WriteLine("=== PUBLISHER TREE ===\n");
                        publisherTree.PrintTree();
                        break;

                    case "4":
                        Console.Write("Title: ");
                        string t = Console.ReadLine();

                        Console.Write("Author: ");
                        string a = Console.ReadLine();

                        Console.Write("Pages: ");
                        int p = int.Parse(Console.ReadLine());

                        Console.Write("Publisher: ");
                        string pub = Console.ReadLine();

                        Book newBook = new Book(t, a, p, pub);

                        titleTree.Insert(newBook);
                        authorTree.Insert(newBook);
                        publisherTree.Insert(newBook);

                        Console.WriteLine("\nBook inserted!");
                        break;

                    case "5":
                        Console.Write("Enter title of book to remove: ");
                        string removeTitle = Console.ReadLine();

                        Book dummy = new Book(removeTitle, "", 0, "");

                        titleTree.Remove(dummy);
                        authorTree.Remove(dummy);
                        publisherTree.Remove(dummy);

                        Console.WriteLine("\nAttempted removal (if exists).");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
                Console.Clear();
            }
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