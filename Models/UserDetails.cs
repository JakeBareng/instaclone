using Microsoft.AspNetCore.Identity;

namespace instaclone.models
{
    public class UserDetails : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
