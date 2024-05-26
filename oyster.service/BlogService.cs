using MongoDB.Bson;
using oyster.DTO.Request;
using oyster.Repositories;
using oyster.service.Interface;

namespace oyster.service
{
    public class BlogService : IBlogService
    {
        private readonly BlogRepository blogRepository;

        public BlogService(BlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<List<DTO.Blog>> GetBlogsAsync()
        {
            var blogs = await blogRepository.GetBlogsAsync();

            return blogs.Select(d => Map(d)).ToList();
        }

        public async Task<DTO.Blog> GetBlogAsync(string blogId)
        {

            var blog = await blogRepository.GetBlogAsync(ToObjectId(blogId));

            return Map(blog);
        }

        public async Task DeleteBlogAsync(string blogId)
        {
            await blogRepository.DeleteBlogAsync(ToObjectId(blogId));
        }

        public async Task<DTO.Blog> CreateBlogAsync(CreateBlogRequest blog)
        {
            if (blog.Title != null || blog.Description != null)
            {
                //   return new CommonErrorException("Title and Description is required!");
            }

            var crateBlog = new oyster.DB.Entities.Blog
            {
                Title = blog.Title,
                Description = blog.Description,
                CreatedAt = DateTime.Now,
            };

            var createdBlog = await blogRepository.CreateBlogAsync(crateBlog);

            return Map(createdBlog);
        }

        public async Task<DTO.Blog> UpdateBlogAsync(string blogId, UpdateBlogRequest blog)
        {
            var oldBlog = await blogRepository.GetBlogAsync(ToObjectId(blogId));
            if (oldBlog != null)
            {
                //  return new CommonErrorException(HttpStatusCode.NotFound,"Blog not found!");
            }

            var crateBlog = new oyster.DB.Entities.Blog
            {
                Title = blog.Title,
                Description = blog.Description,
                UpdatedAt = DateTime.Now,
                CreatedAt = oldBlog.CreatedAt,
                Id = oldBlog.Id
            };

            var createdBlog = await blogRepository.UpdateBlogAsync(ToObjectId(blogId), crateBlog);

            return Map(createdBlog);

        }

        private DTO.Blog Map(oyster.DB.Entities.Blog blog)
        {
            return new DTO.Blog
            {
                Id = blog.Id.ToString(),
                Title = blog.Title,
                Description = blog.Description,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt,
            };
        }

        public static ObjectId ToObjectId(string id)
        {
            try
            {
                return ObjectId.Parse(id);
            }
            catch
            {
                return ObjectId.Empty;
            }
        }
    }
}
