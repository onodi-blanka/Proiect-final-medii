using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }
        public IEnumerable<SelectListItem> Pets { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }

        public IActionResult OnGet()
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

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
