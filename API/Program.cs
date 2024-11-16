using API.Data;
using Microsoft.EntityFrameworkCore;

const string ANGULAR_CORS_POLICY = "AngularPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    string? connString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connString);
});
builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddPolicy(ANGULAR_CORS_POLICY, policy => {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("https://localhost:4200");
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors(ANGULAR_CORS_POLICY);
app.UseAuthorization();
app.MapControllers();

app.Run();