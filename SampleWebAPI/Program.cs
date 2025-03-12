using SampleWebAPI;
using SampleWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// DI�ݒ�
builder.Services.AddSingleton<ISampleService, SampleService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS�|���V�[�̒ǉ��i�S�I���W���A�S���\�b�h�A�S�w�b�_�[�����j
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

// CORS�~�h���E�F�A�̒ǉ��iAuthorization���O�ɔz�u�j
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
