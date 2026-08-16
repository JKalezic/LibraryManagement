using NUnit.Framework;

[TestFixture]
public class LibraryTests
{
    private Library _library;

    [SetUp]
    public void SetUp()
    {
        _library = new Library();
        _library.AddBook("1984", "Orwell");
        _library.AddBook("Dune", "Herbert");
        _library.AddMember("Jovana");
    }

    [Test]
    public void BorrowBook_AvailableBook_MarksAsUnavailable()
    {
        _library.BorrowBook(1, 1);

        Book? book = _library.FindBook(1);
        Assert.That(book, Is.Not.Null);
        Assert.That(book.IsAvailable, Is.False);
    }

    [Test]
    public void AddBook_NewBook_IsAvailableByDefault()
    {
        _library.AddBook("The Hobbit", "Tolkien");

        Book? book = _library.FindBook(3);
        Assert.That(book, Is.Not.Null);
        Assert.That(book.IsAvailable, Is.True);
    }

    [Test]
    public void BorrowBook_InvalidBookId_DoesNotCrash()
    {
        Assert.DoesNotThrow(() => _library.BorrowBook(5, 1));
    }

    [Test]
    public void BorrowBook_InvalidMemberId_DoesNotCrash()
    {
        Assert.DoesNotThrow(() => _library.BorrowBook(1, 123));
    }

    [Test]
    public void BorrowBook_AlreadyBorrowed_RemainsUnavailable()
    {
        _library.BorrowBook(1, 1);
        _library.BorrowBook(1, 1);

        Book? book = _library.FindBook(1);
        Assert.That(book, Is.Not.Null);
        Assert.That(book.IsAvailable, Is.False);
    }

    [Test]
    public void ReturnBook_BorrowedBook_MarksAsAvailable()
    {
        _library.BorrowBook(1, 1);
        _library.ReturnBook(1, 1);

        Book? book = _library.FindBook(1);
        Assert.That(book, Is.Not.Null);
        Assert.That(book.IsAvailable, Is.True);
    }

    [Test]
    public void ReturnBook_UpdatesMemberBorrowedBooks()
    {
        _library.BorrowBook(1, 1);
        _library.ReturnBook(1, 1);

        Member? member = _library.FindMember(1);
        Assert.That(member, Is.Not.Null);
        Assert.That(member.BorrowedBooks.Count, Is.EqualTo(0));
    }
}