using System.ComponentModel.DataAnnotations;

namespace instaclone.Models.DTOs
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string? UserCreatedUsername { get; set; }
        public string? ProfilePicture { get; set; }

    }
}
