using Microsoft.Extensions.Options;
using MongoDbProject.Api.Services.Category;
using MongoDbProject.Api.Services.Product;
using MongoDbProject.Api.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection("DataBaseSettings"));

builder.Services.AddSingleton<IDataBaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DataBaseSettings>>().Value;
});
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
