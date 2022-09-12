using Checkout_Kata.Models;

namespace Checkout_Kata.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        // Fakers

        // Mocks

        // Sut
        private Checkout _checkout;

        [TestInitialize]
        public void BeforeEachTest()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    ProductName = "A",
                    ProductPrice = 0.5M
                },
                new Product
                {
                    ProductName = "B",
                    ProductPrice = 1.0M
                },
            };

            _checkout = new Checkout(products);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Item scanned")]
        public void Handle_When_Nothing_Scanned()
        {
            // Act
            _checkout.ScanItem("");
        }

        [TestMethod]
        public void Handle_When_Item_Scanned()
        {
            // Arrange
            _checkout.ScanItem("A");

            // Act
            var result = _checkout.CalculateTotal();

            // Assert
            Assert.AreEqual(0.5M, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Item scanned")]
        public void Handle_When_Scanned_Doesnt_Exist()
        {
            // Act
            _checkout.ScanItem("F");
        }

        [TestMethod]
        public void Handle_When_Two_Similar_Items_Scanned()
        {
            // Arrange
            _checkout.ScanItem("A");
            _checkout.ScanItem("A");

            // Act
            var result = _checkout.CalculateTotal();

            // Assert
            Assert.AreEqual(1.0M, result);
        }

        [TestMethod]
        public void Handle_When_Two_Different_Items_Scanned()
        {
            // Arrange
            _checkout.ScanItem("A");
            _checkout.ScanItem("B");

            // Act
            var result = _checkout.CalculateTotal();

            // Assert
            Assert.AreEqual(1.5M, result);
        }
    }
}