using MongoDB.Bson;
using MongoDB.Driver;
using oyster.DB;
using oyster.DB.Entities;
using oyster.Repositories.Interface;

namespace oyster.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IMongoCollection<Blog> blogsCollection;

        public BlogRepository(IOysterBlogDbSettings oysterBlogDbSettings)
        {
            MongoClient client = new MongoClient(oysterBlogDbSettings.ConnectionString);

            IMongoDatabase database = client.GetDatabase(oysterBlogDbSettings.DatabaseName);

            this.blogsCollection = database.GetCollection<Blog>(oysterBlogDbSettings.BlogsCollectionName);
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
