using Hex.Sample.Module.Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;


namespace Hex.Sample.Module.Library.Application.Books;

public class GetBooksFeature
{
    public static async Task<IResult> Handle(IBookRepository bookRepository)
    {
        var entities = await bookRepository.GetAll();
        return Results.Ok(entities);
    }
}
