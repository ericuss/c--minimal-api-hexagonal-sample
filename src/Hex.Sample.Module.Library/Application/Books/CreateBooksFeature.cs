using Hex.Sample.Module.Library.Infrastructure.Repositories;
using Hex.Sample.Sdk.Contracts.Books;
using Microsoft.AspNetCore.Http;


namespace Hex.Sample.Module.Library.Application.Books;

public class CreateBooksFeature
{
    public static async Task<IResult> Handle(IBookRepository bookRepository, Book dto)
    {
        if (string.IsNullOrWhiteSpace(dto?.Name))
        {
            return Results.BadRequest(new { error = $"{nameof(Book.Name)} is null or whitespace"});

        }
        var entity = new Domain.Book.Builder()
                        .SetName(dto.Name)
                        .Build();

        var response = await bookRepository.Create(entity);
        return Results.Ok(response);
    }
}
