using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Invoice Invoice { get; set; }
        public IEnumerable<SelectListItem> Appointments { get; set; }

        public IActionResult OnGet()
        {
            Appointments = _context.Appointments.Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = $"Appointment {a.ID}"
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
                    Text = $"Appointment {a.ID}"
                }).ToList();

            }

            _context.Invoices.Add(Invoice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
