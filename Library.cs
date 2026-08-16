public class Library
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();
    private int nextBookId = 1;
    private int nextMemberId = 1;

    public void AddBook(string title, string author)
    {
        books.Add(new Book(nextBookId, title, author));
        nextBookId++;
        Console.WriteLine($"✓ Book added: {title} by {author}");
    }

    public void AddMember(string name)
    {
        members.Add(new Member(nextMemberId, name));
        nextMemberId++;
        Console.WriteLine($"✓ Member added: {name}");
    }

    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books in library.");
            return;
        }
        foreach (Book book in books)
        {
            string status = book.IsAvailable ? "Available" : "Borrowed";
            Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} [{status}]");
        }
    }

    public void ListMembers()
    {
        if (members.Count == 0)
        {
            Console.WriteLine("No members registered.");
            return;
        }
        foreach (Member member in members)
        {
            Console.WriteLine($"{member.Id}. {member.Name} — {member.BorrowedBooks.Count} book(s) borrowed");
        }
    }


    public void BorrowBook(int bookId, int memberId)
    {
        Book? book = books.Find(b => b.Id == bookId);
        Member? member = members.Find(m => m.Id == memberId);

        if (book == null)
        {
            Console.WriteLine($"No book found with ID {bookId}.");
            return;
        }
        if (member == null)
        {
            Console.WriteLine($"No member found with ID {memberId}.");
            return;
        }
        if (!book.IsAvailable)
        {
            Console.WriteLine($"'{book.Title}' is not available.");
            return;
        }

        book.IsAvailable = false;
        member.BorrowedBooks.Add(book);
        Console.WriteLine($"✓ '{book.Title}' borrowed by {member.Name}.");
    }

    public Book? FindBook(int bookId)
    {
        return books.Find(b => b.Id == bookId);
    }

    public Member? FindMember(int memberId)
    {
        return members.Find(m => m.Id == memberId);
    }

    public void ReturnBook(int bookId, int memberId)
    {
        Book? book = books.Find(b => b.Id == bookId);
        Member? member = members.Find(m => m.Id == memberId);

        if (book == null || member == null)
        {
            Console.WriteLine("Invalid book or member ID.");
            return;
        }

        book.IsAvailable = true;
        member.BorrowedBooks.Remove(book);
        Console.WriteLine($"✓ '{book.Title}' returned by {member.Name}.");
    }

    public void SearchBooks(string keyword)
    {
        List<Book> results = books.FindAll(b =>
            b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (results.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }
        foreach (Book book in results)
        {
            string status = book.IsAvailable ? "Available" : "Borrowed";
            Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} [{status}]");
        }
    }

    public void MemberBooks(int memberId)
    {
        Member? member = members.Find(m => m.Id == memberId);

        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }
        if (member.BorrowedBooks.Count == 0)
        {
            Console.WriteLine($"{member.Name} has no borrowed books.");
            return;
        }
        Console.WriteLine($"{member.Name}'s borrowed books:");
        foreach (Book book in member.BorrowedBooks)
        {
            Console.WriteLine($"  {book.Id}. {book.Title} by {book.Author}");
        }
    }

    public void Seed()
    {
        string[] titles =
        {
            "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "Brave New World", "The Lord of the Rings", "Harry Potter", "The Hobbit", "Fahrenheit 451", "Jane Eyre", "Wuthering Heights", "The Alchemist", "Don Quixote", "Anna Karenina", "War and Peace", "Crime and Punishment", "The Brothers Karamazov", "Moby Dick", "The Odyssey", "The Iliad", "Hamlet", "Macbeth", "Romeo and Juliet", "A Midsummer Night's Dream", "The Divine Comedy", "Les Misérables", "The Count of Monte Cristo", "The Three Musketeers", "Around the World in 80 Days", "Journey to the Center of the Earth", "Dracula", "Frankenstein", "The Picture of Dorian Gray", "Sherlock Holmes", "The War of the Worlds", "The Time Machine", "Animal Farm", "Lord of the Flies", "The Old Man and the Sea", "For Whom the Bell Tolls", "A Farewell to Arms", "The Sun Also Rises", "Of Mice and Men", "East of Eden", "Grapes of Wrath", "Catch-22", "Slaughterhouse-Five", "One Flew Over the Cuckoo's Nest", "Dune"
        };

        string[] authors =
        {
            "F. Scott Fitzgerald", "Harper Lee", "George Orwell", "Jane Austen", "J.D. Salinger", "Aldous Huxley", "J.R.R. Tolkien", "J.K. Rowling", "J.R.R. Tolkien", "Ray Bradbury", "Charlotte Bronte", "Emily Bronte", "Paulo Coelho", "Miguel de Cervantes", "Leo Tolstoy", "Leo Tolstoy", "Fyodor Dostoevsky", "Fyodor Dostoevsky", "Herman Melville", "Homer", "Homer", "William Shakespeare", "William Shakespeare", "William Shakespeare", "William Shakespeare", "Dante Alighieri", "Victor Hugo", "Alexandre Dumas", "Alexandre Dumas", "Jules Verne", "Jules Verne", "Bram Stoker", "Mary Shelley", "Oscar Wilde", "Arthur Conan Doyle", "H.G. Wells", "H.G. Wells", "George Orwell", "William Golding", "Ernest Hemingway", "Ernest Hemingway", "Ernest Hemingway", "Ernest Hemingway", "John Steinbeck", "John Steinbeck", "John Steinbeck", "Joseph Heller", "Kurt Vonnegut", "Ken Kesey", "Frank Herbert"
        };

        for (int i = 0; i < 50; i++)
        {
            books.Add(new Book(nextBookId, titles[i], authors[i]));
            nextBookId++;
        }

        string[] names =
        {
            "Alice Johnson", "Bob Smith", "Carol White", "David Brown", "Emma Davis", "Frank Miller", "Grace Wilson", "Henry Moore", "Isabel Taylor", "James Anderson"
        };
        for (int i = 0; i < 10; i++)
        {
            members.Add(new Member(nextMemberId, names[i]));
            nextMemberId++;
        }

        Console.WriteLine("✓ 50 books seeded.");
        Console.WriteLine("✓ 10 members seeded.");


    }
}