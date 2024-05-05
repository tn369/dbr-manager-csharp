using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    internal sealed record MailAddress
    {
        public MailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"MailAddress を null または空白にすることはできません。", nameof(value));
            }

            Value = value;
        }

        public string Value { get; }
    }
}
