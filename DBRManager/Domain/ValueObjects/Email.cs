using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed partial record Email
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
                throw new ArgumentException($"Email を null または空白にすることはできません。", nameof(value));
            }

            var regex = truePattern();
            if (!regex.IsMatch(value))
            {
                throw new ArgumentException($"Email の形式が誤っています。", nameof(value));
            }

            if (value.Length > 254)
            {
                throw new ArgumentException("Email が長すぎます。", nameof(value));
            }

            foreach (var item in value.Split("@"))
            {
                if (item.StartsWith('.'))
                {
                    throw new ArgumentException($"Email の形式が誤っています。", nameof(value));
                }

                if (item.EndsWith('.'))
                {
                    throw new ArgumentException($"Email の形式が誤っています。", nameof(value));
                }
            }
        }
        public string Value { get; }

        [GeneratedRegex(@"^[a-zA-Z0-9!#$%&'*+\-/=?^_`{|}~.]+@[a-zA-Z0-9!#$%&'*+\-/=?^_`{|}~.]+$")]
        private static partial Regex truePattern();
    }
}
