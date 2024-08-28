namespace instaclone.Models.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string FileAddress { get; set; }
        public string Caption { get; set; }
        public DateTime Created { get; set; }
        public UserDTO InstaCloneUser { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<LikeDTO> Likes { get; set; }
    }
}
