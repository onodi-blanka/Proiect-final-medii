using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Doctor = await _context.Doctors.FindAsync(id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Doctor = await _context.Doctors.FindAsync(id);

            if (Doctor != null)
            {
                _context.Doctors.Remove(Doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
