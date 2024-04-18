using IplTeams.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IplTeams.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<team> Teams { get; set; }
    }
}
