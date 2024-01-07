using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data;
using Proiect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proiect.Pages.Pets
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Owners { get; set; }
        public IActionResult OnGet()
        {
            Owners = _context.Owners.Select(o => new SelectListItem
            {
                Value = o.ID.ToString(),
                Text = $"{o.FirstName} {o.LastName}"
            }).ToList();

            return Page();
        }

        [BindProperty]
        public Pet Pet { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Owners = await _context.Owners.Select(o => new SelectListItem
                {
                    Value = o.ID.ToString(),
                    Text = $"{o.FirstName} tavee {o.LastName}"
                }).ToListAsync();

            }

            _context.Pets.Add(Pet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}