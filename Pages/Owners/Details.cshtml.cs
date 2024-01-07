using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Owners
{
	public class OwnerDetailsModel : PageModel
	{
		private readonly ApplicationDbContext _context;

		public OwnerDetailsModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public Owner Owner { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Owner = await _context.Owners.FirstOrDefaultAsync(m => m.ID == id);

			if (Owner == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}
