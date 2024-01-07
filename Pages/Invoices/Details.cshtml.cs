using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Data;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Pages.Invoices
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Invoice = await _context.Invoices
                .Include(i => i.Appointment)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Invoice == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

}
