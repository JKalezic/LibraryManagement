public class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public Member(int id, string name)
    {
        Id = id;
        Name = name;
        BorrowedBooks = new List<Book>();
    }
}