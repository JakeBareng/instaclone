using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace instaclone.models
{
    public class InstaCloneUser : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? UserCreatedUsername {  get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
