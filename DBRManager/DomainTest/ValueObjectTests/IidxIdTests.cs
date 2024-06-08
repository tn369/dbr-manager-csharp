using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class IidxIdTests
    {
        [Fact]
        public void NULLの場合エラー()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("IidxId を null または空白にすることはできません。", exception.Message);
        }

        [Fact]
        public void スペースの場合エラー()
        {
            string value = "   ";

            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("IidxId を null または空白にすることはできません。", exception.Message);
        }

        [Theory]
        [InlineData("1234-5678")]
        [InlineData("12345678")]
        public void 正しい形式の場合エラーが発生しない(string value)
        {
            var exceptionRecord = Record.Exception(() => new IidxId(value));
            Assert.Null(exceptionRecord);
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("1234-56789")]
        [InlineData("abcd-5678")]
        public void 桁数と使用文字が異なる場合はエラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("IidxId の形式が誤っています。", exception.Message);
        }

        [Theory]
        [InlineData("1234-5678", "1234-5678")]
        [InlineData("12345678", "1234-5678")]
        public void Valueプロパティがハイフン付きになる(string value, string trueValue)
        {
            var obj = new IidxId(value);
            Assert.Equal(obj.Value, trueValue);
        }

        [Theory]
        [InlineData("1234-5678", "12345678")]
        [InlineData("1234-5678", "1234-5678")]
        [InlineData("12345678", "12345678")]
        public void 値が等価なら同一オブジェクトと判定される(string value, string trueValue)
        {
            Assert.Equal(new IidxId(value), new IidxId(trueValue));
        }

        [Theory]
        [InlineData("1234-5678", "12345677")]
        [InlineData("1234-5678", "1234-5677")]
        [InlineData("12345678", "12345677")]
        public void 値が異なればなら異なるオブジェクトと判定される(string value, string trueValue)
        {
            Assert.NotEqual(new IidxId(value), new IidxId(trueValue));
        }

        [Theory]
        [InlineData("１２３４-５６７８", "1234-5678")]
        [InlineData("１２３４５６７８", "1234-5678")]
        public void 全角数値が半角数値に変換される(string value, string trueValue)
        {
            var obj = new IidxId(value);
            Assert.Equal(obj.Value, trueValue);
        }
    }
}