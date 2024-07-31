using instaclone.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace instaclone.data;
public class ApplicationDbContext :  IdentityDbContext<UserDetails>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
    { }
}
