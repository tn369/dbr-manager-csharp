namespace Domain.ValueObjects
{
    public sealed record Email
    {
        public Email(string value)
        {
            Validate(value);
            Value = value;
        }

        private static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(value));
            }

            if (value.Length > 254)
            {
                throw new ArgumentException("Email is too long.", nameof(value));
            }

            if (!value.Contains('@'))
            {
                throw new ArgumentException("Email must contain '@'.", nameof(value));
            }

            if (value.StartsWith('.') || value.EndsWith('.'))
            {
                throw new ArgumentException("Email cannot start or end with '.'.", nameof(value));
            }

            var atIndex = value.IndexOf('@');
            var localPart = value[..atIndex];
            var domainPart = value[(atIndex + 1)..];

            if (string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart))
            {
                throw new ArgumentException("Email must have text before and after '@'.", nameof(value));
            }
        }

        public string Value { get; }
    }
}
