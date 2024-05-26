using oyster.DB;
using oyster.Repositories;
using oyster.service;
using oyster_blog;

var builder = WebApplication.CreateBuilder(args);

var appBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings1.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var config = appBuilder.Build();

builder.Services.AddSingleton<IConfiguration>(config);

// Add services to the container.
//builder.Services.AddSingleton<IAppConfig, AppConfig>();

builder.Services.AddSingleton<IOysterBlogDbSettings, AppConfig>();
builder.Services.AddSingleton<BlogService>();
builder.Services.AddSingleton<BlogRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
