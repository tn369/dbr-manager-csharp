using System.Text.RegularExpressions;

namespace Domain.Modules
{
    static internal partial class StringExtensions
    {
        /// <summary>
        /// 全角数字を半角数字に変換する。
        /// </summary>
        /// <param name="value">変換する文字列</param>
        /// <returns>変換後の文字列</returns>
        static public string ConvertFullToHalfNumbers(this string value)
        {
            return FullNumbers().Replace(value, p => ((char)(p.Value[0] - '０' + '0')).ToString());
        }

        [GeneratedRegex("[０-９]")]
        private static partial Regex FullNumbers();
    }
}
