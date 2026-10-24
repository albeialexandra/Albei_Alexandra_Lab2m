using Albei_Alexandra_Lab2m.Models;

public class Author
{
    public int ID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public ICollection<Book>? Books { get; set; }
}