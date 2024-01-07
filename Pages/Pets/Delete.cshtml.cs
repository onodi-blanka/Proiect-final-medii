using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Pets
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pet Pet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pet = await _context.Pets.FirstOrDefaultAsync(m => m.ID == id);

            if (Pet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pet = await _context.Pets.FindAsync(id);

            if (Pet != null)
            {
                _context.Pets.Remove(Pet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }

}
