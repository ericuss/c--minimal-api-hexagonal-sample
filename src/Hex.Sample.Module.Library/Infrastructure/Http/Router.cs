namespace Hex.Sample.Module.Library.Infrastructure.Http;

using Hex.Sample.Module.Library.Application.Books;
using Hex.Sample.Module.Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

public static class Router
{
    public static WebApplication RegisterLibraryRoutes(this WebApplication app)
    {
        //const string route = "/api/v{version:apiVersion}/books";
        const string route = "/api/books";

        app.MapGet(route, async ([FromServices] IBookRepository repository) =>  await GetBooksFeature.Handle(repository));
        return app;
    }
}
