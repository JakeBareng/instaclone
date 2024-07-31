namespace instaclone.models
{
    public class Like
    {
        public int LikeID { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }

        public UserDetails user { get; set; }
        public Post post { get; set; }
    }
}
