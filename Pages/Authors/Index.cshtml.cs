using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chisalita_Daniel_Lab2.Models;

namespace Chisalita_Daniel_Lab2.Pages.AuthorPages;

public class IndexModel : PageModel
{
    private readonly Chisalita_Daniel_Lab2Context _context;

    public IndexModel(Chisalita_Daniel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Author> Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Author = await _context.Author.ToListAsync();
    }
}
