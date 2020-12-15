using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalCalendar.data.Entities;

namespace PersonalCalendar.data.DatabaseContext.AuthenticationDbContext
{
   public class AuthenticationDbContext : IdentityDbContext <ApplicationUser> 
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }
        public DbSet<Schedule> Schedule { get; set; }
    }
}
 