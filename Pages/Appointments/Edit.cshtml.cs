using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }
        public IEnumerable<SelectListItem> Pets { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Appointment = await _context.Appointments.FindAsync(id);

            if (Appointment == null)
            {
                return NotFound();
            }

            Pets = _context.Pets.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.Name
            }).ToList();

            Doctors = _context.Doctors.Select(d => new SelectListItem
            {
                Value = d.ID.ToString(),
                Text = $"{d.FirstName} {d.LastName}"
            }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Pets = _context.Pets.Select(p => new SelectListItem
                {
                    Value = p.ID.ToString(),
                    Text = p.Name
                }).ToList();

                Doctors = _context.Doctors.Select(d => new SelectListItem
                {
                    Value = d.ID.ToString(),
                    Text = $"{d.FirstName} {d.LastName}"
                }).ToList();

            }

            _context.Attach(Appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
