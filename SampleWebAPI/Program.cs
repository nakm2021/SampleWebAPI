using SampleWebAPI;
using SampleWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// DI設定
builder.Services.AddSingleton<ISampleService, SampleService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORSポリシーの追加（全オリジン、全メソッド、全ヘッダーを許可）
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORSミドルウェアの追加（Authorizationより前に配置）
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
