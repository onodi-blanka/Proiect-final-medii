using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Owners
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owner Owner { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Owner = await _context.Owners.FindAsync(id);

            if (Owner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Owner = await _context.Owners.FindAsync(id);

            if (Owner != null)
            {
                _context.Owners.Remove(Owner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
