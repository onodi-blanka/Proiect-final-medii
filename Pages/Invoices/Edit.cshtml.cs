using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Invoice Invoice { get; set; }
        public IEnumerable<SelectListItem> Appointments { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Invoice = await _context.Invoices.FindAsync(id);

            if (Invoice == null)
            {
                return NotFound();
            }

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

            _context.Attach(Invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
