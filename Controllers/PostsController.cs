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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace instaclone.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly SocialMediaContext _context;

        public PostsController(SocialMediaContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostRequest postRequest)
        {

            var post = await _context.Posts.FindAsync(id);
            var user = _context.UserDetails.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (post == null || user == null)
                return BadRequest();

            if (!post.UserDetail.Id.Equals(user.Id))
                return Unauthorized();


            post.Title = postRequest.title;
            post.FileAddress = postRequest.fileAddress;
            post.Caption = postRequest.caption;

            _context.Entry(post).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(PostRequest postRequest)
        {
            var user = _context.UserDetails.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null)
            {
                return BadRequest();
            }

            var post = new Post
            {
                Caption = postRequest.caption,
                Comments = new List<Comment>(),
                FileAddress = postRequest.fileAddress,
                Title = postRequest.title,
                UserDetail = user,
            };


            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            var user = _context.UserDetails.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (post == null || user == null)
                return BadRequest();

            if (!post.UserDetail.Id.Equals(user.Id))
                return Unauthorized();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
