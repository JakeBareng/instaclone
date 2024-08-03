using instaclone.models;
using Microsoft.EntityFrameworkCore;

namespace instaclone.Data
{
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options) : base(options) { } 
        public DbSet<Comment> Comments { get; set; }
        public DbSet<InstaCloneUser> InstaCloneUser { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.InstaCloneUser, l.Post });
        }
    }

}
