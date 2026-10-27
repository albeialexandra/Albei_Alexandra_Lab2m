using Microsoft.AspNetCore.Mvc.RazorPages;
using Albei_Alexandra_Lab2m;

namespace Albei_Alexandra_Lab2m.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList { get; set; } = new();

        public void PopulateAssignedCategoryData(Albei_Alexandra_Lab2mContext context, Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
                (book.BookCategories ?? new List<BookCategory>()).Select(c => c.CategoryID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateBookCategories(Albei_Alexandra_Lab2mContext context,
            string[]? selectedCategories, Book bookToUpdate)
        {
            bookToUpdate.BookCategories ??= new List<BookCategory>();

            var selected = new HashSet<string>(selectedCategories ?? Array.Empty<string>());
            var current = new HashSet<int>(bookToUpdate.BookCategories.Select(c => c.CategoryID));

            foreach (var cat in context.Category)
            {
                if (selected.Contains(cat.ID.ToString()))
                {
                    if (!current.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else if (current.Contains(cat.ID))
                {
                    var toRemove = bookToUpdate.BookCategories.Single(i => i.CategoryID == cat.ID);
                    context.Remove(toRemove);
                }
            }
        }
    }
}