using instaclone.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace instaclone.Data
{
    public class SocialMediaContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options, IConfiguration configuration) : base(options) 
        { 
            Configuration = configuration;
        } 
        public DbSet<Comment> Comments { get; set; }
        public DbSet<InstaCloneUser> InstaCloneUser { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("API_DB"));
        }
    }

}
