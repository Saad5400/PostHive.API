using Microsoft.EntityFrameworkCore;
using PostHive.Model;

namespace PostHive.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.RepliedToComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.RepliedToCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UpvotedPosts)
                .WithMany(p => p.UpvotedBy)
                .UsingEntity(j => j.ToTable("UserUpvotedPosts"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.DownvotedPosts)
                .WithMany(p => p.DownvotedBy)
                .UsingEntity(j => j.ToTable("UserDownvotedPosts"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.UpvotedComments)
                .WithMany(c => c.UpvotedBy)
                .UsingEntity(j => j.ToTable("UserUpvotedComments"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.DownvotedComments)
                .WithMany(c => c.DownvotedBy)
                .UsingEntity(j => j.ToTable("UserDownvotedComments"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
