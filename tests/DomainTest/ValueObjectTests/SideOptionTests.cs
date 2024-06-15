﻿using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class SideOptionTests
    {
        [Fact]
        public void SideOption_Constructor_ShouldInitializeProperties()
        {
            var randomOption = new RandomOption(RandomOptionType.Normal);
            var sideOption = new SideOption(randomOption);

            Assert.Equal(randomOption, sideOption.RandomOption);
        }

        [Fact]
        public void SideOption_Constructor_WithNullRandomOption_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SideOption(null));
        }
    }
}