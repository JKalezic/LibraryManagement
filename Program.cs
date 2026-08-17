using System.Diagnostics.CodeAnalysis;

Library library = new Library();

Console.WriteLine("=== Library Management System ===");
Console.WriteLine("Commands: add book, add member, list books, list members,");
Console.WriteLine("borrow books, return books, search books, search member books, seed test data, quit");
Console.WriteLine();

library.Load();

while (true)
{
    Console.Write("> ");
    string? input = Console.ReadLine();

    if (input == "quit")
    {
        library.Save();
        Console.WriteLine("Goodbye!");
        break;
    }

    else if (input == "add book")
    {
        Console.Write("Title: ");
        string? title = Console.ReadLine();
        Console.Write("Author: ");
        string? author = Console.ReadLine();
        library.AddBook(title ?? "Unknown", author ?? "Unknown");
    }

    else if (input == "add member")
    {
        Console.Write("Name: ");
        string? name = Console.ReadLine();
        library.AddMember(name ?? "Unknown");
    }

    else if (input == "list books") { library.ListBooks(); }

    else if (input == "list members") { library.ListMembers(); }

    else if (input == "search books")
    {
        Console.WriteLine("Search: ");
        string? keyword = Console.ReadLine();
        library.SearchBooks(keyword ?? "");
    }

    else if (input == "borrow books")
    {
        Console.Write("Book ID: ");
        if (int.TryParse(Console.ReadLine(), out int bookId))
        {
            Console.WriteLine("Member ID: ");
            if (int.TryParse(Console.ReadLine(), out int memberId))
                library.BorrowBook(bookId, memberId);
            else
                Console.WriteLine("Invalid Member ID");
        }
        else
        {
            Console.WriteLine("Invalid Book ID");
        }
    }

    else if (input == "return books")
    {
        Console.WriteLine("Book ID: ");
        if (int.TryParse(Console.ReadLine(), out int bookId))
        {
            Console.WriteLine("Member ID: ");
            if (int.TryParse(Console.ReadLine(), out int memberId))
                library.ReturnBook(bookId, memberId);
            else
                Console.WriteLine("Invalid Member ID");
        }
        else
        {
            Console.WriteLine("Invalid Book ID");
        }
    }

    else if (input == "search member books")
    {
        Console.WriteLine("Member ID: ");
        if (int.TryParse(Console.ReadLine(), out int memberId))
            library.MemberBooks(memberId);
        else
            Console.WriteLine("Invalid Member ID");
    }

    else if (input == "seed")
    {
        library.Seed();
    }

    else
    {
        Console.WriteLine("Unknown command. Please try again.");
    }
}