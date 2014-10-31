using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Should.Fluent;
using T7.Katas.StringCalculator;

namespace T7.Katas.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        //http://osherove.com/tdd-kata-1/
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void GivenEmptyString_Returns0()
        {
            _calculator.Add("").Should().Equal(0);
        }

        [Test]
        public void GivenSingleNumber_ReturnsIt()
        {
            _calculator.Add("5").Should().Equal(5);
        }

        [Test]
        public void GivenTwoNumbers_ReturnsSum()
        {
            _calculator.Add("3,8").Should().Equal(11);
        }

        [Test]
        public void GivenEightNumbers_ReturnsSum()
        {
            _calculator.Add("1,1,1,1,1,1,1,1").Should().Equal(8);
        }

        [Test]
        public void GivenSeparatedByEndOfLine_ReturnsSum()
        {
            _calculator.Add("1\n3").Should().Equal(4);
        }

        [Test]
        public void GivenDelimiter_ReturnsSum()
        {
            _calculator.Add("//;\n1;4;7").Should().Equal(12);
        }

        [Test]
        public void GivenOtherDelimiter_ReturnsSum()
        {
            _calculator.Add("//:\n1:5:2").Should().Equal(8);
        }

        [Test]
        public void GivenNegativeNumber_Throws()
        {
            var ex = NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() => 
                _calculator.Add("1,4,-5"));

            ex.Message.Should().Contain("No negatives allowed - -5");
        }

        [Test]
        public void GivenNegativeNumbers_ThrowsOneMessageForAll()
        {
            var ex = NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() =>
                _calculator.Add("-1,-4,-5"));

            ex.Message.Should().Contain("No negatives allowed - -1,-4,-5");
        }

        [Test]
        public void GivenBigNumbers_IgnoresThem()
        {
            _calculator.Add("1,4,1001").Should().Equal(5);
        }

        [Test]
        public void Given1000_IncludesIt()
        {
            _calculator.Add("1,4,1000").Should().Equal(1005);
        }
    }
}
