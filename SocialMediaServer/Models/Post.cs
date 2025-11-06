using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialMediaServer.Models
{
    public class Post
    {
        // MongoDB 使用 ObjectId 作為唯一識別碼
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("user_id")]
        public int UserId { get; set; }

        [BsonElement("username")]
        public string? Username { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }

        [BsonElement("tags")]
        public List<string>? Tags { get; set; }

        [BsonElement("likes_count")]
        public int LikesCount { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
