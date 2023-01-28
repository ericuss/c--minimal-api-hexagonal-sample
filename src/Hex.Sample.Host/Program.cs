using Hex.Sample.Module.User.Infrastructure.Http;
using Hex.Sample.Module.User;
using Hex.Sample.Infrastructure.Contexts;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//services

builder.Services
    .ConfigureUsers(builder.Configuration)
    ;



//app

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var scope = app.Services.CreateScope();
    var usersContext = scope.ServiceProvider.GetService<Hex.Sample.Module.User.Infrastructure.Database.UsersContext>();
#pragma warning disable CS8631 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match constraint type.
    ContextInitialize.InitializeDb(usersContext, app.Configuration, "Sql").Wait();
#pragma warning restore CS8631 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match constraint type.
    scope.Dispose();
}

app
    .RegisterUserRoutes()
    .MapGet("/", () => "Hello World!")
    ;

app.Run();
public partial class Program { }
