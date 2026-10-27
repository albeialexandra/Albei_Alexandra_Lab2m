using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m.Models;
using Albei_Alexandra_Lab2m.ViewModels;

namespace Albei_Alexandra_Lab2m.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly Albei_Alexandra_Lab2mContext _context;

        public IndexModel(Albei_Alexandra_Lab2mContext context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; } = default!;
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(c => c.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}