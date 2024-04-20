using Haha.Music.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Haha.Music.Persistence
{
    public class HahaMusicDbContext : AuditableDbContext
    {
        public HahaMusicDbContext(DbContextOptions<HahaMusicDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HahaMusicDbContext).Assembly);
        }

        //public DbSet<LeaveRequestRepository> LeaveRequests { get; set; }
    }
}
