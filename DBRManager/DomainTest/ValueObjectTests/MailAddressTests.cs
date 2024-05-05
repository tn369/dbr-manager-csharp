﻿using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class MailAddressTests
    {
        [Fact]
        public void NULLの場合エラー()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress を null または空白にすることはできません。", exception.Message);
        }

        [Fact]
        public void スペースの場合エラー()
        {
            string value = "   ";

            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress を null または空白にすることはできません。", exception.Message);
        }

        [Theory]
        [InlineData ("aieuo1234gmail.com")]
        [InlineData ("^-0987654321gmail.com")]
        public void アットマークがない場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress の形式が誤っています。", exception.Message);
        }

        [Theory]
        [InlineData("@")]
        [InlineData("@gmail.com")]
        [InlineData("@g")]
        [InlineData("hogehoge@")]
        [InlineData("e@")]
        public void アットマークの前後に文字がない場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress の形式が誤っています。", exception.Message);
        }

        [Theory]
        [InlineData("test@じーめーる.com")]
        [InlineData("test@ｇｍａｉｌ．ｃｏｍ")]
        [InlineData("ｔｅｓｔ@gmail.com")]
        public void 全角文字が含まれる場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress の形式が誤っています。", exception.Message);
        }

        [Theory]
        [InlineData("test@test@gmail.com")]
        [InlineData("test@@gmail.com")]
        [InlineData("test@@@@gmail.com")]
        public void アットマークが複数ある場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress の形式が誤っています。", exception.Message);
        }


        [Theory]
        [InlineData("test@gmail.com.")]
        [InlineData(".test@gmail.com")]
        [InlineData("test.@gmail.com")]
        [InlineData("test@.gmail.com")]
        public void 先頭末尾にドットがある場合エラー(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress の形式が誤っています。", exception.Message);
        }

        // RFC規定上はNGだが携帯キャリアメールの一部で許容されるケースがあるため除外
        // https://ja.wikipedia.org/wiki/%E3%83%A1%E3%83%BC%E3%83%AB%E3%82%A2%E3%83%89%E3%83%AC%E3%82%B9
        //[Theory]
        //[InlineData("test@gmail..com.")]
        //[InlineData("test..test@gmail.com")]
        //public void ドットが二連続している場合エラー(string value)
        //{
        //    var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
        //    Assert.Contains("MailAddress の形式が誤っています。", exception.Message);
        //}
    }
}
