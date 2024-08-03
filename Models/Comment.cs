using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace instaclone.models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String? Content {  get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;



        public string InstaCloneUserId { get; set; }
        [Required]
        public InstaCloneUser InstaCloneUser { get; set; }


        public int PostId { get; set; }
        [Required]
        public Post Post { get; set; }
    }
}
