namespace Hex.Sample.Module.User.Domain
{
    public class User
    {
        private User()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; internal set; }

        public string Name { get; internal set; } = default!;



        public User SetName(string? name)
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

            public User Build()
            {
                var entity = new User()
                    .SetName(this.name)
                ;

                return entity;
            }
        }
    }
}