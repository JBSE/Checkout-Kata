namespace Checkout_Kata.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        // Fakers

        // Mocks

        // SUT
        private Checkout _checkout;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _checkout = new Checkout();
        }

        [TestMethod]
        public void Handle_When_Nothing_Is_Scanned()
        {
            // Arrange
            var result = _checkout.CalculateTotal();

            // Act
            Assert.AreEqual(0M, result);
        }
    }
}