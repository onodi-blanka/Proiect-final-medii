using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Doctors
{
	public class DetailsModel : PageModel
	{
		private readonly ApplicationDbContext _context;

		public DetailsModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public Doctor Doctor { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.ID == id);

			if (Doctor == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}
