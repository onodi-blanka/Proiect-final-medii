using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Owners
{
	public class CreateModel : PageModel
	{
		private readonly ApplicationDbContext _context;

		public CreateModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Owner Owner { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Owners.Add(Owner);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
