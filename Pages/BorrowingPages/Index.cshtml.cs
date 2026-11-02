using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m.Models;
using Albei_Alexandra_Lab2m;

namespace Albei_Alexandra_Lab2m.Pages.BorrowingPages;

public class IndexModel : PageModel
{
    private readonly Albei_Alexandra_Lab2mContext _context;

    public IndexModel(Albei_Alexandra_Lab2mContext context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Borrowing != null)
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                    .ThenInclude(b => b.Author)
                .Include(b => b.Member)
                .ToListAsync();
        }
    }
}
