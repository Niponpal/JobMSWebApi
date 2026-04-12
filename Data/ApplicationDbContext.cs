using JobMSWebApi.model;
using Microsoft.EntityFrameworkCore;

namespace JobMSWebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // add this

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .Property(a => a.CGPA)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Application>()
                .Property(a => a.PresentSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Application>()
                .Property(a => a.ExpectionSalary)
                .HasPrecision(18, 2);
        }

    }
}
