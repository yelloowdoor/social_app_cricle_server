using Microsoft.AspNetCore.Mvc;
using SocialMediaServer.Models;
using SocialMediaServer.Services;

namespace SocialMediaServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get()
        {
            // 呼叫服務層方法取得所有貼文
            var posts = await _postService.GetAsync();

            if (posts is null || posts.Count == 0)
            {
                return NotFound("No posts found.");
            }

            return Ok(posts);
        }
    }
}
