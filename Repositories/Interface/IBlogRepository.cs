using MongoDB.Bson;
using oyster_blog.Repositories.Entity;
using oyster_blog.Service.DTO.Request;

namespace oyster_blog.Repositories.Interface
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlogsAsync();

        Task<Blog> GetBlogAsync(ObjectId blogId);

        Task DeleteBlogAsync(ObjectId blogId);

        Task<Blog?> CreateBlogAsync(Blog? blog);

        Task<Blog> UpdateBlogAsync(ObjectId blogId, Blog blog);
    }
}
