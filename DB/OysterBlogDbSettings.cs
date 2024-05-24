namespace oyster_blog.DB
{
    public class OysterBlogDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BlogsCollectionName { get; set; } = null!;
    }
}
