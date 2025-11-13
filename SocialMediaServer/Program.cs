using SocialMediaServer.Models;
using SocialMediaServer.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. 定義一個 CORS 策略名稱
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// 添加 CORS 服務
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // ⚠️ 開發階段最簡單的做法：允許所有來源、所有標頭、所有方法
                          // 正式環境中應將 .AllowAnyOrigin() 替換為 .WithOrigins("https://your.app.com")
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));
// 註冊 PostService 為單例服務，並注入 IConfiguration
builder.Services.AddSingleton<PostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// 2. 啟用 CORS 中介軟體，並使用我們剛剛定義的策略
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
