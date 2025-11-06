using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SocialMediaServer.Models;

namespace SocialMediaServer.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _postsCollection;

        // 構造函數：初始化連線
        public PostService(IOptions<MongoDBSettings> postDatabaseSetting)
        {

        }

        // 取得所有貼文的方法
        public async Task<List<Post>> GetAsync() =>
            await _postsCollection.Find(_ => true).ToListAsync();

        // 根據 ID 取得單一貼文的方法
        public async Task<Post?> GetByIdAsync(string id) =>
            await _postsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // 更多方法 (Create, Update, Remove) 可以在此添加...
    }
}
