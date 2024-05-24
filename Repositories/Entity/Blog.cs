using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace oyster_blog.Repositories.Entity
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // TODO add created by and updated by
    }
}
