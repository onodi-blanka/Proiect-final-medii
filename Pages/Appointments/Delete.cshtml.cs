using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Appointments
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Appointment = await _context.Appointments.FindAsync(id);

            if (Appointment != null)
            {
                _context.Appointments.Remove(Appointment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }

}
