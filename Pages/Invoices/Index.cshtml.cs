using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoices { get; set; }

        public async Task OnGetAsync()
        {
            Invoices = await _context.Invoices
                .Include(i => i.Appointment)
                .ToListAsync();
        }
    }

}
