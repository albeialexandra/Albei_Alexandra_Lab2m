using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m.Models;
using Albei_Alexandra_Lab2m;

namespace Albei_Alexandra_Lab2m.Pages.CategoryPages;

public class DetailsModel : PageModel
{
    private readonly Albei_Alexandra_Lab2mContext _context;
    public DetailsModel(Albei_Alexandra_Lab2mContext context)
    {
        _context = context;
    }

    public Category Category { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
        if (category is null)
        {
            return NotFound();
        }
        else
        {
            Category = category;
        }

        return Page();
    }
}
