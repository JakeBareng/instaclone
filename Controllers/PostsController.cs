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
using instaclone.Models.DTOs;
using instaclone.Models.RequestModels;
using System.Reflection.Metadata;
using Azure.Storage.Blobs;

namespace instaclone.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly SocialMediaContext _context;
        private readonly BlobStorageService _blobStorageService = new BlobStorageService();

        public PostsController(SocialMediaContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        //{

        //temp
        public string GetPosts() { 

            //temp
            return "test";


            //var user = _context.InstaCloneUser.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //if (user == null)
            //    return NotFound("User does not exist");

            //var posts = await _context.Posts
            //    .Include(p => p.InstaCloneUser)
            //    .Include(p => p.Comments)
            //    .Include(p => p.Likes)
            //    .ToListAsync();
               
            //var postDTOs = posts.Select(p => new PostDTO
            //{
            //    Id = p.Id,
            //    FileAddress = p.FileAddress,
            //    Caption = p.Caption,
            //    Created = p.Created,
            //    InstaCloneUser = new UserMap().mapUser(p.InstaCloneUser),
            //    Comments = p.Comments.Select(c => new CommentMap().mapComment(c)).ToList(),
            //    Likes = p.Likes.Select(l => new LikeMap().mapLike(l)).ToList()
            //});

            //return postDTOs.ToList();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var user = _context.InstaCloneUser.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null)
                return NotFound();


            var post = await _context.Posts
                .Include(p => p.InstaCloneUser)
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return NotFound();

            var postDTO = new PostDTO
            {
                Id = post.Id,
                FileAddress = post.FileAddress,
                Caption = post.Caption,
                Created = post.Created,
                InstaCloneUser = new UserMap().mapUser(post.InstaCloneUser),
                Comments = post.Comments.Select(c => new CommentMap().mapComment(c)).ToList(),
                Likes = post.Likes.Select(l => new LikeMap().mapLike(l)).ToList()
            };

            return postDTO;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, string caption)
        {

            var post = await _context.Posts.FindAsync(id);
            var user = _context.InstaCloneUser.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (post == null || user == null)
                return BadRequest();

            if (!post.InstaCloneUser.Id.Equals(user.Id))
                return Unauthorized();


            post.Caption = caption;

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
                    throw new Exception("Error updating post");
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostDTO>> PostPost([FromForm] PostRequest postRequest)
        {
            var user = await _context.InstaCloneUser.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null)
                return NotFound("user not found");


            long maxSize = 3000000;

            if (postRequest.file.Length > maxSize)
                return BadRequest("file size is too large");

            string uri = await _blobStorageService.UploadFileAsync(
                postRequest.file.OpenReadStream(),
                postRequest.file.FileName);


            var post = new Post
            {
                Caption = postRequest.caption,
                FileAddress = uri, 
                InstaCloneUser = user,
            };


            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, new PostDTO
            {
                Id = post.Id,
                FileAddress = post.FileAddress,
                Caption = post.Caption,
                Created = post.Created,
                InstaCloneUser = new UserMap().mapUser(post.InstaCloneUser),
                Comments = post.Comments.Select(c => new CommentMap().mapComment(c)).ToList(),
                Likes = post.Likes.Select(l => new LikeMap().mapLike(l)).ToList()
            });
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            var user = _context.InstaCloneUser.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (post == null || user == null)
                return BadRequest();

            if (!post.InstaCloneUser.Id.Equals(user.Id))
                return Unauthorized();


            string blobname = post.FileAddress;
            _blobStorageService.DeleteFile(blobname);


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
