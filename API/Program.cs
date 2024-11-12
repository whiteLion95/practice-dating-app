using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    string? connString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connString);
});
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();