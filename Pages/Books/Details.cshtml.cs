using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m;
using Albei_Alexandra_Lab2m.Models;

namespace Albei_Alexandra_Lab2m.Pages.BookPages
{
    public class DetailsModel : PageModel
    {
        private readonly Albei_Alexandra_Lab2mContext _context;

        public DetailsModel(Albei_Alexandra_Lab2mContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories).ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }

            Book = book;
            return Page();
        }
    }
}