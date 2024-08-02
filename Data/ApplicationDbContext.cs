using instaclone.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace instaclone.data;
public class ApplicationDbContext :  IdentityDbContext<InstaCloneUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<InstaCloneUser> InstaCloneUsers { get; set; }

}
