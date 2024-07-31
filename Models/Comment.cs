using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace instaclone.models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public int PostID {  get; set; }
        public String? Content {  get; set; }
        public DateTime Created { get; set; }

        public UserDetails user { get; set; }
        public Post post { get; set; }
    }
}
