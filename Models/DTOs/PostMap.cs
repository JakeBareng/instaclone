using instaclone.models;

namespace instaclone.Models.DTOs
{
    public class PostMap
    {
        public PostDTO mapPost(Post post)
        {
            return new PostDTO
            {
                Id = post.Id,
                FileAddress = post.FileAddress,
                Caption = post.Caption,
                Created = post.Created,
                InstaCloneUser = new UserMap().mapUser(post.InstaCloneUser),
                Comments = post.Comments.Select(c => new CommentMap().mapComment(c)).ToList(),
                Likes = post.Likes.Select(l => new LikeMap().mapLike(l)).ToList()
            };
        }
    }
}
