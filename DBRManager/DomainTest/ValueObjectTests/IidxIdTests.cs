using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class IidxIdTests
    {
        [Fact]
        public void NULL�̏ꍇ�G���[()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("IidxId �� null �܂��͋󔒂ɂ��邱�Ƃ͂ł��܂���B", exception.Message);
        }

        [Fact]
        public void �X�y�[�X�̏ꍇ�G���[()
        {
            string value = "   ";

            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("IidxId �� null �܂��͋󔒂ɂ��邱�Ƃ͂ł��܂���B", exception.Message);
        }

        [Theory]
        [InlineData("1234-5678")]
        [InlineData("12345678")]
        public void �������`���̏ꍇ�G���[���������Ȃ�(string value)
        {
            var exceptionRecord = Record.Exception(() => new IidxId(value));
            Assert.Null(exceptionRecord);
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("1234-56789")]
        [InlineData("abcd-5678")]
        public void �����Ǝg�p�������قȂ�ꍇ�̓G���[(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("IidxId �̌`��������Ă��܂��B", exception.Message);
        }

        [Theory]
        [InlineData("1234-5678", "1234-5678")]
        [InlineData("12345678", "1234-5678")]
        public void Value�v���p�e�B���n�C�t���t���ɂȂ�(string value, string trueValue)
        {
            var obj = new IidxId(value);
            Assert.Equal(obj.Value, trueValue);
        }

        [Theory]
        [InlineData("1234-5678", "12345678")]
        [InlineData("1234-5678", "1234-5678")]
        [InlineData("12345678", "12345678")]
        public void �l�������Ȃ瓯��I�u�W�F�N�g�Ɣ��肳���(string value, string trueValue)
        {
            Assert.Equal(new IidxId(value), new IidxId(trueValue));
        }

        [Theory]
        [InlineData("1234-5678", "12345677")]
        [InlineData("1234-5678", "1234-5677")]
        [InlineData("12345678", "12345677")]
        public void �l���قȂ�΂Ȃ�قȂ�I�u�W�F�N�g�Ɣ��肳���(string value, string trueValue)
        {
            Assert.NotEqual(new IidxId(value), new IidxId(trueValue));
        }

        [Theory]
        [InlineData("�P�Q�R�S-�T�U�V�W", "1234-5678")]
        [InlineData("�P�Q�R�S�T�U�V�W", "1234-5678")]
        public void �S�p���l�����p���l�ɕϊ������(string value, string trueValue)
        {
            var obj = new IidxId(value);
            Assert.Equal(obj.Value, trueValue);
        }
    }
}