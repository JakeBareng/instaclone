namespace instaclone.Models.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public UserDTO InstaCloneUser { get; set; }
    }
}
