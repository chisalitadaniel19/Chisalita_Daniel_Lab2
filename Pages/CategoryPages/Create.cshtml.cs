using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chisalita_Daniel_Lab2.Pages.CategoryPages;

public class CreateModel : PageModel
{
    private readonly Chisalita_Daniel_Lab2Context _context;

    public CreateModel(Chisalita_Daniel_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Category Category { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Category.Add(Category);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
