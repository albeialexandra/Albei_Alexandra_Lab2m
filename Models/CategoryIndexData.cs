using Albei_Alexandra_Lab2m.Models;

namespace Albei_Alexandra_Lab2m.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}