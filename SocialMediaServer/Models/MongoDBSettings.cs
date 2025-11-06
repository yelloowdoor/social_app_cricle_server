namespace SocialMediaServer.Models
{
    public class MongoDBSettings
    {
        // 在 appsettings.json 中的區段名稱，如 "BookStoreDatabase"
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
