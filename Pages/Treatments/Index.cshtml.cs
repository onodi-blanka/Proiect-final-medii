using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Treatments
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Treatment> Treatments { get; set; }

        public async Task OnGetAsync()
        {
            Treatments = await _context.Treatments
                .Include(t => t.Appointment)
                .ToListAsync();
        }
    }

}
