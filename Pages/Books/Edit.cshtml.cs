using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m.Models;

namespace Albei_Alexandra_Lab2m.Pages.BookPages
{
    public class EditModel : PageModel
    {
        private readonly Albei_Alexandra_Lab2mContext _context;

        public EditModel(Albei_Alexandra_Lab2mContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null) return NotFound();

            Book = book;
            LoadDropdowns();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Book.Author");
            ModelState.Remove("Book.Publisher");

            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Book.Any(e => e.ID == Book.ID))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private void LoadDropdowns()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FullName", Book?.AuthorID);
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName", Book?.PublisherID);
        }
    }
}
