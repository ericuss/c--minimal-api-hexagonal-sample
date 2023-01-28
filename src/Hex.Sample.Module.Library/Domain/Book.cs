using Newtonsoft.Json;

namespace Hex.Sample.Module.Library.Domain;

public class Book
{
    private Book()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; internal set; }

    public string Name { get; internal set; } = default!;



    public Book SetName(string? name)
    {
        //refactor to use result (maybe pattern)
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"{nameof(Name)} cannot be null or whitespace");
        }

        Name = name;
        return this;
    }

    public class Builder
    {
        private string? name;

        public Builder SetName(string? name)
        {
            this.name = name;
            return this;
        }

        public Book Build()
        {
            var entity = new Book()
                .SetName(this.name)
            ;

            return entity;
        }
    }
}
