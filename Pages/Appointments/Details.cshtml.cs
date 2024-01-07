using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Appointments
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Appointment = await _context.Appointments
                .Include(a => a.Pet)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

}
