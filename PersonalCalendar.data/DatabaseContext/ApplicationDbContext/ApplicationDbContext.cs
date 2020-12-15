using Microsoft.EntityFrameworkCore;
using PersonalCalendar.data.Entities;

namespace PersonalCalendar.data.DatabaseContext.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options)
        {
        }
        public DbSet <Schedule> Schedule { get; set; }
    }
}
