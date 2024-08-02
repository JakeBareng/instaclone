using System.ComponentModel.DataAnnotations.Schema;

namespace instaclone.models
{
    public class Like
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public InstaCloneUser UserDetail { get; set; }
        public Post Post { get; set; }
    }
}
