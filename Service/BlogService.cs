using oyster_blog.Service.DTO;
using oyster_blog.Service.DTO.Request;
using oyster_blog.Service.Interface;

namespace oyster_blog.Service
{
    public class BlogService: IBlogService
    {
        public Task<List<Blog>> GetBlogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetBlogAsync(string blogId)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> DeleteBlogAsync(string blogId)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> CreateBlogAsync(CreateBlogRequest blog)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> UpdateBlogAsync(string blogId, UpdateBlogRequest blog)
        {
            throw new NotImplementedException();
        }
    }
}
