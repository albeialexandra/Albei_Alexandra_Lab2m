using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m.Models;
using Albei_Alexandra_Lab2m;

namespace Albei_Alexandra_Lab2m.Pages.BorrowingPages;

public class EditModel : PageModel
{
    private readonly Albei_Alexandra_Lab2mContext _context;

    public EditModel(Albei_Alexandra_Lab2mContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .Include(b => b.Book)
            .Include(b => b.Member)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (borrowing is null)
        {
            return NotFound();
        }
        Borrowing = borrowing;

        PopulateDropdowns();
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PopulateDropdowns();
            return Page();
        }

        _context.Attach(Borrowing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BorrowingExists(Borrowing.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private void PopulateDropdowns()
    {
        var bookList = _context.Book
            .Include(b => b.Author)
            .Select(x => new
            {
                x.ID,
                BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
            });

        ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
    }

    private bool BorrowingExists(int id)
    {
        return _context.Borrowing.Any(e => e.ID == id);
    }
}