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

    }
}
