using Microsoft.EntityFrameworkCore;
using PostHive.Model;

namespace PostHive.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}
