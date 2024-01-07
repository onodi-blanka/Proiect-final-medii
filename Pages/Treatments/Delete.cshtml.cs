using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data;
using Proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Pages.Treatments
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Treatment Treatment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Treatment = await _context.Treatments
                .Include(t => t.Appointment)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Treatment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Treatment = await _context.Treatments.FindAsync(id);

            if (Treatment != null)
            {
                _context.Treatments.Remove(Treatment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }

}
