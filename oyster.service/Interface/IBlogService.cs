using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oyster.DTO;
using oyster.DTO.Request;

namespace oyster.service.Interface
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
