using instaclone.models;

namespace instaclone.Models.DTOs
{
    public class LikeMap
    {
        public LikeDTO mapLike(Like like)
        {
            return new LikeDTO
            {
                Id = like.Id,
                InstaCloneUser = new UserMap().mapUser(like.InstaCloneUser),
            };
        }
    }
}
