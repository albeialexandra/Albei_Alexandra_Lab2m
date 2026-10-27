using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m.Models;

namespace Albei_Alexandra_Lab2m.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Albei_Alexandra_Lab2mContext _context;

        public DetailsModel(Albei_Alexandra_Lab2mContext context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            Author = author;
            return Page();
        }
    }
}