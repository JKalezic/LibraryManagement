using System.Text.Json;


public class DataStorage
{
    private const string BooksFile = "books.json";
    private const string MembersFile = "members.json";

    public void SaveBooks(List<Book> books)
    {
        string json = JsonSerializer.Serialize(books, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(BooksFile, json);
    }

    public void SaveMembers(List<Member> members)
    {
        string json = JsonSerializer.Serialize(members, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(MembersFile, json);
    }

    public List<Book> LoadBooks()
    {
        if (!File.Exists(BooksFile))
            return new List<Book>();

        try
        {
            string json = File.ReadAllText(BooksFile);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Warning: books.json is corrupted. Starting with empty book list.");
            return new List<Book>();
        }
    }

    public List<Member> LoadMembers()
    {
        if (!File.Exists(MembersFile))
            return new List<Member>();

        try
        {
            string json = File.ReadAllText(MembersFile);
            return JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Warning: members.json is corrupted. Starting with empty member list.");
            return new List<Member>();
        }
    }
}



