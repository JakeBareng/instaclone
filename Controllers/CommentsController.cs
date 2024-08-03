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
    public class CommentsController : ControllerBase
    {
        private readonly SocialMediaContext _context;

        public CommentsController(SocialMediaContext context)
        {
            _context = context;
        }


        // GET: api/Comments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Comment>> GetComment(int id)
        //{
        //    var comment = await _context.Comments.FindAsync(id);

        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return comment;
        //}




        // GET: api/Comments/Post/5
        // Get all comments for a post
        [HttpGet("Post/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForPost(int id)
        {
            return await _context.Comments.Where(c => c.PostId == id).ToListAsync();
        }


        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentRequest commentRequest)
        {

            var comment = await _context.Comments.FindAsync(id);
            var user = await _context.InstaCloneUser.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));


            if (comment == null || user == null)
            {
                return NotFound();
            }

            if (!comment.InstaCloneUser.Id.Equals(user.Id))
            {
                return Unauthorized();
            }

            comment.Content = commentRequest.Content;


            // Update the comment content
            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                // Update the comment content
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments/Post/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Post/{id}")]
        public async Task<ActionResult<Comment>> PostComment(int postId ,CommentRequest commentRequest)
        {
            
            var user = await _context.InstaCloneUser.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var post = await _context.Posts.FindAsync(postId);

            if (user == null || post == null)
            {
                return BadRequest();
            }

            var comment = new Comment
            {
                Content = commentRequest.Content,
                Post = post,
                InstaCloneUser = user
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var user = await _context.InstaCloneUser.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null || user == null)
            {
                return NotFound();
            }

            if (!comment.InstaCloneUser.Id.Equals(user.Id))
            {
                return Unauthorized();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
