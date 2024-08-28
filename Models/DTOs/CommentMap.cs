using instaclone.models;

namespace instaclone.Models.DTOs
{
    public class CommentMap
    {
        public CommentDTO mapComment(Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                Created = comment.Created,
                InstaCloneUser = new UserMap().mapUser(comment.InstaCloneUser),
            };
        }
    }
}
