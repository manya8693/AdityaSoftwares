using AdityaSoftwares.Models;
using Microsoft.EntityFrameworkCore;

namespace AdityaSoftwares.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<ApplicatinUsers> ApplicationUser { get; set; }
        public DbSet<Visitors> Visitor { get; set; }
    }
}
