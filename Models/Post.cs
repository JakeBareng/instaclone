using System.Diagnostics.CodeAnalysis;

namespace instaclone.models
{
    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public String? FileAddress { get; set; }
        public String? Title {  get; set; }
        public String? Caption { get; set; }
        public DateTime Created { get; set; }
        public UserDetails user { get; set; }
    }
}
