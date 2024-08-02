using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace instaclone.models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String? FileAddress { get; set; }
        public String? Title {  get; set; }
        public String? Caption { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public InstaCloneUser UserDetail { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
