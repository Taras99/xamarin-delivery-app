using DeliveryApp.Models;
using NUnit.Framework;

namespace DeliveryApp.Tests.Models
{
    [TestFixture]
    public class CartItemTests
    {
        [Test]
        public void CartItem_DefaultValues_AreEmpty()
        {
            var item = new CartItem();

            Assert.That(item.CartItemId, Is.EqualTo(0));
            Assert.That(item.ProductId, Is.EqualTo(0));
            Assert.That(item.ProductName, Is.Null);
            Assert.That(item.Price, Is.EqualTo(0));
            Assert.That(item.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void CartItem_SetProperties_RetainsValues()
        {
            var item = new CartItem
            {
                CartItemId = 1,
                ProductId = 42,
                ProductName = "Pizza Margherita",
                Price = 9.99m,
                Quantity = 3
            };

            Assert.That(item.CartItemId, Is.EqualTo(1));
            Assert.That(item.ProductId, Is.EqualTo(42));
            Assert.That(item.ProductName, Is.EqualTo("Pizza Margherita"));
            Assert.That(item.Price, Is.EqualTo(9.99m));
            Assert.That(item.Quantity, Is.EqualTo(3));
        }

        [Test]
        public void CartItem_Price_SupportsDecimalPrecision()
        {
            var item = new CartItem { Price = 12.345m };

            Assert.That(item.Price, Is.EqualTo(12.345m));
        }
    }
}
