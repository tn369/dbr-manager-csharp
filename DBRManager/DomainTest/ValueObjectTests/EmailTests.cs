using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class EmailTests
    {
        [Fact]
        public void NULLの場合エラー()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email を null または空白にすることはできません。", exception.Message);
        }

        [Fact]
        public void スペースの場合エラー()
        {
            string value = "   ";

            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email を null または空白にすることはできません。", exception.Message);
        }

        [Theory]
        [InlineData ("aieuo1234gmail.com")]
        [InlineData ("^-0987654321gmail.com")]
        public void アットマークがない場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email の形式が誤っています。", exception.Message);
        }

        [Theory]
        [InlineData("@")]
        [InlineData("@gmail.com")]
        [InlineData("@g")]
        [InlineData("hogehoge@")]
        [InlineData("e@")]
        public void アットマークの前後に文字がない場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email の形式が誤っています。", exception.Message);
        }

        [Theory]
        [InlineData("test@じーめーる.com")]
        [InlineData("test@ｇｍａｉｌ．ｃｏｍ")]
        [InlineData("ｔｅｓｔ@gmail.com")]
        public void 全角文字が含まれる場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email の形式が誤っています。", exception.Message);
        }

        [Theory]
        [InlineData("test@test@gmail.com")]
        [InlineData("test@@gmail.com")]
        [InlineData("test@@@@gmail.com")]
        public void アットマークが複数ある場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email の形式が誤っています。", exception.Message);
        }


        [Theory]
        [InlineData("test@gmail.com.")]
        [InlineData(".test@gmail.com")]
        [InlineData("test.@gmail.com")]
        [InlineData("test@.gmail.com")]
        public void 先頭末尾にドットがある場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email の形式が誤っています。", exception.Message);
        }

        // RFC規定上はNGだが携帯キャリアメールの一部で許容されるケースがあるため除外
        // https://ja.wikipedia.org/wiki/%E3%83%A1%E3%83%BC%E3%83%AB%E3%82%A2%E3%83%89%E3%83%AC%E3%82%B9
        //[Theory]
        //[InlineData("test@gmail..com.")]
        //[InlineData("test..test@gmail.com")]
        //public void ドットが二連続している場合エラー(string value)
        //{
        //    var exception = Assert.Throws<ArgumentException>(() => new Email(value));
        //    Assert.Contains("Email の形式が誤っています。", exception.Message);
        //}

        //@TODO:ダブルクォートに対応
        //[Theory]
        //[InlineData("Abc@example.com")]
        //[InlineData("test@gmail.com")]
        //[InlineData("Abc.123@example.com")]
        //[InlineData("user+mailbox/department=shipping@example.com")]
        //[InlineData("!#$%&'*+-/=?^_`.{|}~@example.com")]
        //[InlineData("\"Abc@def\"@example.com")]
        //[InlineData("\"Fred\\ Bloggs\"@example.com")]
        //[InlineData("\"Joe.\\\\Blow\\"\"@example.com")]

        //public void 正しいパターンの場合はエラーが発生しない(string value)
        //{
        //    var exception = Assert.Throws<ArgumentException>(() => new Email(value));
        //    Assert.Null(exception);
        //}
        [Fact]
        public void 文字数が２５４文字を超える場合エラー()
        {
            var value = new string('a', 253) + "@a";
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email が長すぎます。", exception.Message);
        }

        [Fact]
        public void 文字数が２５４文字以内の場合正常()
        {
            var value = new string('a', 252) + "@a";
            var exception = Record.Exception(() => new Email(value));
            Assert.Null(exception);
        }
    }
}
