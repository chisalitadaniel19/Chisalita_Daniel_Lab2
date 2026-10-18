using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chisalita_Daniel_Lab2.Models;

namespace Chisalita_Daniel_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Chisalita_Daniel_Lab2Context _context;

        public IndexModel(Chisalita_Daniel_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}