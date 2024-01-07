using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Data;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Invoice = await _context.Invoices.FindAsync(id);

            if (Invoice != null)
            {
                _context.Invoices.Remove(Invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }

}
