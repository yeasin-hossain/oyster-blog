using Microsoft.AspNetCore.Mvc;
using oyster_blog.Service;
using oyster_blog.Service.DTO;
using oyster_blog.Service.DTO.Request;

namespace oyster_blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService blogService;

        public BlogController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet] 
        public async Task<List<Blog>> GetBlogs() => await blogService.GetBlogsAsync();

        [HttpGet("{blogId}")]
        public async Task<Blog> GetBlog(string blogId) => await blogService.GetBlogAsync(blogId);

        [HttpPost]
        public async Task<Blog> CreateBlog(CreateBlogRequest blog) => await blogService.CreateBlogAsync(blog);

        [HttpPut("{blogId}")]
        public async Task<Blog> UpdateBlog(string blogId, UpdateBlogRequest blog) => 
            await blogService.UpdateBlogAsync(blogId, blog);

        [HttpDelete("{blogId}")]
        public async Task DeleteBlog(string blogId) => await blogService.DeleteBlogAsync(blogId);
    }
}
