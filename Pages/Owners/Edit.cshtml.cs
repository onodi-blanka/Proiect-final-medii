using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Owners
{
	public class EditModel : PageModel
	{
		private readonly ApplicationDbContext _context;

		public EditModel(ApplicationDbContext context)
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

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Owner).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!OwnerExists(Owner.ID))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool OwnerExists(int id)
		{
			return _context.Owners.Any(e => e.ID == id);
		}
	}
}
