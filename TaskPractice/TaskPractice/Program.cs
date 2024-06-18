using Microsoft.EntityFrameworkCore;
using TaskPractice.Data.Model;
using TaskPractice.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();//This Is BY DEFAULT Provide Attribute Routing
builder.Services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("ProductCategory")));
builder.Services.AddScoped<ICategory, Category1>();
builder.Services.AddScoped<ICategoryAsync, CategoryAsync>();
builder.Services.AddScoped<ILogin, Login>();
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
