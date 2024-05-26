using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using oyster.DB.Entities;

namespace oyster.Repositories.Interface
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
