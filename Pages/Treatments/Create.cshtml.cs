using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Treatments
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Treatment Treatment { get; set; }
        public IEnumerable<SelectListItem> Appointments { get; set; }

        public IActionResult OnGet()
        {
            Appointments = _context.Appointments.Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = $"Appointment {a.ID}" // Modify as needed
            }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Appointments = _context.Appointments.Select(a => new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = $"Appointment {a.ID}" // Modify as needed
                }).ToList();

            }

            _context.Treatments.Add(Treatment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
