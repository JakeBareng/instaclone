using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using instaclone.Data;
using instaclone.models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace instaclone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly SocialMediaContext _context;

        public LikesController(SocialMediaContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        // get all likes from current user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId == null)
                return BadRequest();

            return await _context.Likes.Where(l => l.InstaCloneUser.Id == userId.Value).ToListAsync();
        }


        // GET: api/Likes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Like>> GetLike(int id)
        //{
        //    var like = await _context.Likes.FindAsync(id);

        //    if (like == null)
        //    {
        //        return NotFound();
        //    }

        //    return like;
        //}

        // GET: api/Likes/Post/5
        // Get all likes for a post
        [HttpGet("Post/{id}")]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikesForPost(int id)
        {
            return await _context.Likes.Where(l => l.Post.Id == id).ToListAsync();
        }

        // POST: api/Likes/Post/5
        // add a like to a post
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Post/{postId}")]
        public async Task<ActionResult<Like>> PostLike(int postId)
        {
            var user = await _context.InstaCloneUser.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var post = await _context.Posts.FindAsync(postId);

            if (user == null || post == null)
                return BadRequest();

            var like = new Like {InstaCloneUser = user, Post = post };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLike", new { id = like.Id }, like);
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            var user = await _context.InstaCloneUser.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var like = await _context.Likes.FindAsync(id);

            if (like == null || user == null)
                return BadRequest();

            if (!like.InstaCloneUser.Id.Equals(user.Id))
                return Unauthorized();


            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeExists(int id)
        {
            return _context.Likes.Any(e => e.Id == id);
        }
    }
}
