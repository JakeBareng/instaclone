using System.ComponentModel.DataAnnotations;

namespace instaclone.Models
{
    public class LoginModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}


