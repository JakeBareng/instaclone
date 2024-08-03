using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace instaclone.models
{
    public class Like
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public string InstaCloneUserId { get; set; }

        [Required]
        public InstaCloneUser InstaCloneUser { get; set; }


        
        public int PostId { get; set; }

        [Required]
        public Post Post { get; set; }
    }
}
