using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tracker.Data.Model;

namespace Tracker.Data
{
    public class TrackerDbContext : IdentityDbContext<ApplicationUser>
    {
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Todo> Todo { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
