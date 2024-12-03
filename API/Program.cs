using API.Extensions;

const string ANGULAR_CORS_POLICY = "AngularPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddIdentityServices(builder.Configuration)
    .AddCorsPolicy(ANGULAR_CORS_POLICY, ["https://localhost:4200"])
    .AddControllers();

var app = builder.Build();

app.UseRouting()
    .UseCors(ANGULAR_CORS_POLICY)
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();
app.Run();