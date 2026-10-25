using Chisalita_Daniel_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chisalita_Daniel_Lab2.Pages.Books;

public class DeleteModel : PageModel
{
    private readonly Chisalita_Daniel_Lab2Context _context;

    public DeleteModel(Chisalita_Daniel_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

        if (book is null)
        {
            return NotFound();
        }
        else
        {
            Book = book;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.BookCategories)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (book != null)
        {
            Book = book;
            _context.Book.Remove(Book);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}