using Domain.Modules;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    /// <summary>
    /// IIDX ID
    /// </summary>
    internal partial record IidxId
    {
        public string Value { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value">設定値</param>
        /// <exception cref="ArgumentException">空白、数値8桁以外の場合</exception>
        public IidxId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"IidxId を null または空白にすることはできません。", nameof(value));
            }
            var regex = truePattern();
            if (!regex.IsMatch(value))
            {
                throw new ArgumentException($"IidxId の形式が誤っています。", nameof(value));
            }

            var formatedValue = regex.Replace(value, "$1-$2").ConvertFullToHalfNumbers();
            Value = formatedValue;
        }

        [GeneratedRegex("^\\s*(\\d{4})-?(\\d{4})\\s*$")]
        private static partial Regex truePattern();
    }
}
