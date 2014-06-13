using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should.Fluent;
using T7.Katas.Bowling;

namespace T7.Katas.Tests
{
    [TestFixture]
    public class BowlingTests
    {
        //http://www.codingdojo.org/cgi-bin/index.pl?KataBowling
        private Bowler _bowler;
        [SetUp]
        public void SetUp()
        {
            _bowler = new Bowler();
        }

        [Test]
        public void GivenNoRolls_ReturnsZero()
        {
            var result = _bowler.Score("");

            result.Should().Equal(0);
        }

        [Test]
        public void GivenMiss_ReturnsZero()
        {
            var result = _bowler.Score("-");

            result.Should().Equal(0);
        }

        [Test]
        public void GivenNumber_ReturnsNumber()
        {
            var result = _bowler.Score("3");

            result.Should().Equal(3);            
        }

        [Test]
        public void GivenX_ReturnsTen()
        {
            var result = _bowler.Score("X");

            result.Should().Equal(10);
        }

        [Test]
        public void GivenNumberThenMiss_ReturnsNumber()
        {
            var result = _bowler.Score("5-");

            result.Should().Equal(5);
        }

        [Test]
        public void GivenNumberThenSpare_ReturnsTen()
        {
            var result = _bowler.Score("5/");

            result.Should().Equal(10);
        }

        [Test]
        public void GivenNumberThenNumber_ReturnsSum()
        {
            var result = _bowler.Score("54");

            result.Should().Equal(9);
        }

        [Test]
        public void GivenSpareThenMiss_ReturnsTen()
        {
            var result = _bowler.Score("5/-");

            result.Should().Equal(10);
        }

        [Test]
        public void GivenSpareThenNumber_Returns10Plus2TimesNumber()
        {
            var result = _bowler.Score("5/5");

            result.Should().Equal(20);
        }

        [Test]
        public void GivenSpareThenStrike_Returns10Plus10Plus10()
        {
            var result = _bowler.Score("5/X");

            result.Should().Equal(30);
        }

        [Test]
        public void GivenStrikeThenOneBallTests()
        {
            _bowler.Score("X-").Should().Equal(10);
            _bowler.Score("X5").Should().Equal(20);
            _bowler.Score("XX").Should().Equal(30);
        }

        [Test]
        public void GivenStrikeThenTwoBallTests()
        {
            _bowler.Score("X--").Should().Equal(10);
            _bowler.Score("X5-").Should().Equal(20);
            _bowler.Score("X-5").Should().Equal(20);
            _bowler.Score("X-X").Should().Equal(30);
            _bowler.Score("X54").Should().Equal(28);
            _bowler.Score("XX-").Should().Equal(30);
            _bowler.Score("XX5").Should().Equal(45);
            _bowler.Score("X5/").Should().Equal(30);
            _bowler.Score("XXX").Should().Equal(60);
            
        }


        [Test]
        public void CompleteGameTests()
        {
            _bowler.Score("XXXXXXXXXXXX").Should().Equal(300);
            _bowler.Score("9-9-9-9-9-9-9-9-9-9-").Should().Equal(90);
            _bowler.Score("5/5/5/5/5/5/5/5/5/5/5").Should().Equal(150);
            
        }
        //[Test] public void Given_(){ }
    }
}
