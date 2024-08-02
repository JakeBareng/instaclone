using Microsoft.AspNetCore.Identity;

namespace instaclone.models
{
    public class InstaCloneUser : IdentityUser
    {
        public string? UserCreatedUsername { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
