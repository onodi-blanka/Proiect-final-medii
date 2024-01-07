using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proiect.Pages.Pets
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pet Pet { get; set; }

        public IEnumerable<SelectListItem> Owners { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pet = await _context.Pets.FindAsync(id);
            if (Pet == null)
            {
                return NotFound();
            }

            Owners = _context.Owners.Select(a =>
                new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Owners = _context.Owners.Select(a =>
             new SelectListItem
             {
                 Value = a.ID.ToString(),
                 Text = $"{a.FirstName} {a.LastName}"
             }).ToList();
            }

            _context.Attach(Pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}

 