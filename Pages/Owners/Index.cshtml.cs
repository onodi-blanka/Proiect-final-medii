using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Owner> Owners { get; set; }

        public async Task OnGetAsync()
        {
            Owners = await _context.Owners.ToListAsync();
        }
    }
}
