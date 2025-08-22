using Microsoft.EntityFrameworkCore;

namespace zhongwen_zhi_lu.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Week> Weeks { get; set; }
    }
}