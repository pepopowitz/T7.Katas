using System.IO;
using System.Reflection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should.Fluent;
using T7.Katas.Anagrams;
using T7.Katas.Tests.Resources;

namespace T7.Katas.Tests
{
    [TestFixture]
    public class AnagramTests
    {
        private Anagrammer _anagrammer;
        
        [SetUp]
        public void SetUp()
        {
            _anagrammer = new Anagrammer();
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullInput_ThrowsArgumentNullException()
        {
            _anagrammer.FindAnagrams(null);
            Assert.Fail("should have thrown, did not.");
        }

        [Test]
        public void GivenEmptyInput_ReturnsEmptyList()
        {
            var result = _anagrammer.FindAnagrams(new string[0]);

            result.Should().Not.Be.Null();
            result.Should().Count.Zero();
        }

        [Test]
        public void GivenOneWord_ReturnsNoAnagrams()
        {
            var input = new string[] {"word"};

            var result = _anagrammer.FindAnagrams(input);

            result.Should().Count.Zero();
        }

        [Test]
        public void GivenThreeUniqueWords_ReturnsNoAnagrams()
        {
            var input = new string[] { "worda", "wordb", "wordc" };

            var result = _anagrammer.FindAnagrams(input);

            result.Should().Count.Zero();
        }

        [Test]
        public void GivenThreeAnagrams_ReturnsOneSet()
        {
            var input = new string[] { "one", "neo", "eno" };

            var result = _anagrammer.FindAnagrams(input);

            result.Should().Count.One();
            result.First().Should().Count.Exactly(3);
        }

        [Test]
        public void GivenThreeAnagrams_ReturnsOriginalWordsInSet()
        {
            var input = new string[] { "one", "neo", "eno" };

            var result = _anagrammer.FindAnagrams(input);

            var first = result.First();
            first.Should().Contain.One(x => x == "one");
            first.Should().Contain.One(x => x == "neo");
            first.Should().Contain.One(x => x == "eno");
        }

        [Test]
        public void GivenThreeAnagramsAndThreeUnique_Returns1Set()
        {
            var input = new string[] { "one", "neo", "eno", "worda", "wordb", "wordc" };

            var result = _anagrammer.FindAnagrams(input);

            result.Should().Count.One();
            result.First().Should().Count.Exactly(3);
        }

        [Test]
        public void GivenThreeAnagramsAndThreeUnique_ReturnsOnlyAnagramsWords()
        {
            var input = new string[] { "one", "neo", "eno", "worda", "wordb", "wordc" };

            var result = _anagrammer.FindAnagrams(input);

            var anagrams = result.First();
            anagrams.Should().Contain.One(x => x == "one");
            anagrams.Should().Contain.One(x => x == "neo");
            anagrams.Should().Contain.One(x => x == "eno");

        }

        [Test]
        public void GivenWordsOfDifferentCase_MatchesAsAnagrams()
        {
            var input = new string[] {"one", "EnO", "NEO"};

            var result = _anagrammer.FindAnagrams(input);

            result.Should().Count.One();
            result.First().Should().Count.Exactly(3);
        }

        [Test]
        public void GivenPunctuation_IgnoresInMatching()
        {
            var input = new string[] { "one", "ne'o", "o-ne" };

            var result = _anagrammer.FindAnagrams(input);

            result.Should().Count.One();
            result.First().Should().Count.Exactly(3);
        }

        [Test]
        public void GivenPunctuation_OriginalsContainPunctuation()
        {
            var input = new string[] { "one", "ne'o", "o-ne" };

            var result = _anagrammer.FindAnagrams(input);

            var anagrams = result.First();
            anagrams.Should().Contain.One(x => x == "one");
            anagrams.Should().Contain.One(x => x == "ne'o");
            anagrams.Should().Contain.One(x => x == "o-ne");
        }


        //[Test]
        //public void GivenFile_Returns20683Sets()
        //{
        //    var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        //    var file = Path.Combine(baseDir, "resources/anagrams-wordlist.txt");

        //    var words = new FileParser().ParseFileIntoWords(file);


        //}
        //[Test] public void GivenNoFile_ThrowsInvalidArgument(){}
    }
}
