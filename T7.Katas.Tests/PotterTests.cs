using System.Runtime.InteropServices;
using NUnit.Framework;
using System;
using Should.Fluent;
using T7.Katas.Potter;


namespace T7.Katas.Tests
{
    [TestFixture]
    public class PotterTests
    {
        private Register _register;

        [SetUp]
        public void SetUp()
        {
            _register = new Register();
        }


        [Test]
        public void GivenNoBooks_PriceIs0()
        {
            var basket = new Basket();
            var price = _register.Total(basket);
            price.Should().Equal(0m);
        }

        [Test]
        public void GivenBook1_PriceIs8()
        {
            var basket = new Basket(Book.Book1);
            var price = _register.Total(basket);
            price.Should().Equal(8m);
            
        }

        [Test]
        public void GivenBooks12_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book2);
            var price = _register.Total(basket);
            price.Should().Equal(16m*.95m);
        }

        [Test]
        public void GivenBooks123_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book2, Book.Book3);
            var price = _register.Total(basket);
            price.Should().Equal(24m * .90m);    
        }

        [Test]
        public void GivenBooks135_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book3, Book.Book5);
            var price = _register.Total(basket);
            price.Should().Equal(24m * .90m);    
        }

        [Test]
        public void GivenBooks1234_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book2, Book.Book3, Book.Book4);
            var price = _register.Total(basket);
            price.Should().Equal(32m * .80m);    
        }

        [Test]
        public void GivenBooks12345_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book2, Book.Book3, Book.Book4, Book.Book5);
            var price = _register.Total(basket);
            price.Should().Equal(40m * .75m);    
        }

        [Test]
        public void GivenBooks11_PriceIs16()
        {
            var basket = new Basket(Book.Book1, Book.Book1);
            var price = _register.Total(basket);
            price.Should().Equal(16m);            
        }

        [Test]
        public void GivenBooks112_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book1, Book.Book2);
            var price = _register.Total(basket);
            price.Should().Equal((16m * .95m) + 8m);
        }

        [Test]
        public void GivenBooks1122_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book1, Book.Book2, Book.Book2);
            var price = _register.Total(basket);
            price.Should().Equal((16m * .95m) + (16m * .95m));
        }

        [Test]
        public void GivenBooks112334_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book1, Book.Book2, Book.Book3, Book.Book3, Book.Book4);
            var price = _register.Total(basket);
            price.Should().Equal((8m*4*.8m) + (16m * .95m));
            
        }

        [Test]
        public void GivenBooks1122334455_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book1, Book.Book2, Book.Book2, Book.Book3, Book.Book3, Book.Book4, Book.Book4, Book.Book5, Book.Book5);
            var price = _register.Total(basket);
            price.Should().Equal(40m*.75m*2);

        }


        [Test]
        public void GivenBooks1112345_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book1, Book.Book1, Book.Book2, Book.Book3, Book.Book4, Book.Book5);
            var price = _register.Total(basket);
            price.Should().Equal((40m * .75m) + (8m * 2m));
        }

        [Test]
        public void GivenBooks11223345_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book1, Book.Book2, Book.Book2, Book.Book3, Book.Book3, Book.Book4, Book.Book5);
            var price = _register.Total(basket);
            price.Should().Equal(51.2m);
        }

        [Test]
        public void GivenBooks1111222233334455_PriceIs0()
        {
            var basket = new Basket(Book.Book1, Book.Book1, Book.Book2, Book.Book2, Book.Book3, Book.Book3, Book.Book4, Book.Book5,
                Book.Book1, Book.Book1, Book.Book2, Book.Book2, Book.Book3, Book.Book3, Book.Book4, Book.Book5);
            var price = _register.Total(basket);
            price.Should().Equal(51.2m*2);
        }
    }
}
