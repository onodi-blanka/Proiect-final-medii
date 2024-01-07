using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointments { get; set; }

        public async Task OnGetAsync()
        {
            Appointments = await _context.Appointments
                .Include(a => a.Pet)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
    }
}
