namespace oyster_blog.DTO
{
    public class Blog
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // TODO add created by and updated by

    }
}
