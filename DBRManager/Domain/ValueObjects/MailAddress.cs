using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    internal sealed partial record MailAddress
    {
        public MailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"MailAddress を null または空白にすることはできません。", nameof(value));
            }

            if (!isValid(value))
            {
                throw new ArgumentException($"MailAddress の形式が誤っています。", nameof(value));
            }
         

            Value = value;
        }

        bool isValid(string value)
        {
            var regex = truePattern();

            if (!regex.IsMatch(value))
            {
                return false;
            }

            foreach (var item in value.Split("@"))
            {
                if (item.StartsWith('.'))
                {
                    return false;
                }

                if (item.EndsWith('.'))
                {
                    return false;
                }
            }
            return true;
        }
        public string Value { get; }

        [GeneratedRegex(@"^[a-zA-Z0-9!#$%&'*+\-/=?^_`{|}~.]+@[a-zA-Z0-9!#$%&'*+\-/=?^_`{|}~.]+$")]
        private static partial Regex truePattern();
    }
}
