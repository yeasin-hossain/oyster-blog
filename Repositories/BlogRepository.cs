using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using oyster_blog.DB;
using oyster_blog.Repositories.Entity;
using oyster_blog.Repositories.Interface;

namespace oyster_blog.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IMongoCollection<Blog> blogsCollection;

        public BlogRepository(IOptions<OysterBlogDbSettings> oysterBlogDbSettings)
        {
            MongoClient client = new MongoClient(oysterBlogDbSettings.Value.ConnectionString);

            IMongoDatabase database = client.GetDatabase(oysterBlogDbSettings.Value.DatabaseName);

            this.blogsCollection = database.GetCollection<Blog>(oysterBlogDbSettings.Value.BlogsCollectionName);
        }

        public async Task<List<Blog>> GetBlogsAsync()
        {
            return await blogsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Blog> GetBlogAsync(ObjectId blogId)
        {
            return await blogsCollection.Find(x => x.Id == blogId).FirstOrDefaultAsync();
        }

        public async Task DeleteBlogAsync(ObjectId blogId)
        {
            await blogsCollection.DeleteOneAsync(x => x.Id == blogId);
        }

        public async Task<Blog?> CreateBlogAsync(Blog? blog)
        {
            await blogsCollection.InsertOneAsync(blog);

            return blog;
        }

        public async Task<Blog> UpdateBlogAsync(ObjectId blogId, Blog blog)
        {
             await blogsCollection.ReplaceOneAsync(x => x.Id == blogId, blog);

             return blog;
        }
    }
}
