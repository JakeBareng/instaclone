using instaclone.models;
using Microsoft.EntityFrameworkCore;

namespace instaclone.Data
{
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options) : base(options) { } 
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserDetails> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }

    }

}
