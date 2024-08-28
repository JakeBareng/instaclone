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
using instaclone.Models.DTOs;
using instaclone.Models.RequestModels;

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
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetCommentsForPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return BadRequest("post id does not exists");


            return await _context.Comments
                .Where(c => c.Post.Id == id)
                .Select(c => new CommentDTO
                {
                    Id = c.Id,
                    Content = c.Content,
                    InstaCloneUser = new UserMap().mapUser(c.InstaCloneUser),
                    Created = c.Created
                })
                .ToListAsync();
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
        [HttpPost("Post/{postId}")]
        public async Task<ActionResult<CommentDTO>> PostComment(int postId ,CommentRequest commentRequest)
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
                PostId = post.Id,
                Post = post,
                InstaCloneUserId = user.Id,
                InstaCloneUser = user,
                Created = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                InstaCloneUser = new UserMap().mapUser(comment.InstaCloneUser),
                Created = comment.Created
            };
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var user = await _context.InstaCloneUser.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var comment = await _context.Comments.FirstAsync(c => c.Id == id);

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
