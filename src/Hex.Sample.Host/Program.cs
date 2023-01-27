using Hex.Sample.Module.User.Infrastructure.Http;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app
    .RegisterUserRoutes()
    .MapGet("/", () => "Hello World!")
    ;

app.Run();
public partial class Program { }
