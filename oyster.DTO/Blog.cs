namespace oyster.DTO
{
    public class Blog
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // TODO add created by and updated by
    }
}
