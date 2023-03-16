using Microsoft.EntityFrameworkCore;

namespace PostHive.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
