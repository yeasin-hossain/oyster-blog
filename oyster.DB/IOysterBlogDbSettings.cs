namespace oyster.DB
{
    public interface IOysterBlogDbSettings
    {
        public string? ConnectionString { get; set; }

        public string? DatabaseName { get; set; } 

        public string? BlogsCollectionName { get; set; }
    }
}
