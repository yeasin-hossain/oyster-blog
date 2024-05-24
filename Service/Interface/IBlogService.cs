using oyster_blog.Service.DTO;
using oyster_blog.Service.DTO.Request;

namespace oyster_blog.Service.Interface
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogsAsync();

        Task<Blog> GetBlogAsync(string blogId);

        Task DeleteBlogAsync(string blogId);

        Task<Blog> CreateBlogAsync(CreateBlogRequest blog);

        Task<Blog> UpdateBlogAsync(string blogId, UpdateBlogRequest blog);
    }
}
