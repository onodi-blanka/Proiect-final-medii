using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data;
using Proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Pages.Treatments
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }

}
