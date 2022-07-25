using GraduationProject.ApplicationLogic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event>? Events { get; set; }
        public DbSet<Attendee>? Attendees { get; set; }
    }
}
