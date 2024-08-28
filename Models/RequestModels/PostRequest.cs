using System.Reflection.Metadata;

namespace instaclone.Models.RequestModels
{
    public class PostRequest
    {
        public string? caption { get; set; }
        public IFormFile file { get; set; }

    }
}
