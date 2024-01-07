using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using Proiect.Data;

namespace Proiect.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctors { get; set; }

        public async Task OnGetAsync()
        {
            Doctors = await _context.Doctors.ToListAsync();
        }
    }
}
