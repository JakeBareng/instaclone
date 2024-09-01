using instaclone.models;

namespace instaclone.Models.DTOs
{
    public class UserMap
    {
        public UserDTO mapUser(InstaCloneUser user)
        {
            return new UserDTO
            {
                Id = user.Id,
                ProfilePicture = user.ProfilePicture,
                UserCreatedUsername = user.UserCreatedUsername
            };
        }
    }
}
