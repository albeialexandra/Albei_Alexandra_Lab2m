namespace Albei_Alexandra_Lab2m.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}