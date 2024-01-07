using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Proiect.Models.Appointment>? Appointments { get; set; }
        public DbSet<Proiect.Models.Doctor>? Doctors { get; set; }
        public DbSet<Proiect.Models.Invoice>? Invoices { get; set; }
        public DbSet<Proiect.Models.Owner>? Owners { get; set; }
        public DbSet<Proiect.Models.Pet>? Pets { get; set; }
        public DbSet<Proiect.Models.Treatment>? Treatments { get; set; }
    }
}