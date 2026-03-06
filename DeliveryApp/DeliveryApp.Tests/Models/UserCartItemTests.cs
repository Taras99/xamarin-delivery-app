using DeliveryApp.Models;
using NUnit.Framework;

namespace DeliveryApp.Tests.Models
{
    [TestFixture]
    public class UserCartItemTests
    {
        [Test]
        public void UserCartItem_SetProperties_RetainsValues()
        {
            var item = new UserCartItem
            {
                CartItemId = 5,
                ProductId = 10,
                ProductName = "Burger",
                Price = 7.50m,
                Quantity = 2,
                Cost = 15.00m
            };

            Assert.That(item.CartItemId, Is.EqualTo(5));
            Assert.That(item.ProductId, Is.EqualTo(10));
            Assert.That(item.ProductName, Is.EqualTo("Burger"));
            Assert.That(item.Price, Is.EqualTo(7.50m));
            Assert.That(item.Quantity, Is.EqualTo(2));
            Assert.That(item.Cost, Is.EqualTo(15.00m));
        }

        [Test]
        public void UserCartItem_Cost_EqualsPrice_Times_Quantity()
        {
            var price = 5.25m;
            var quantity = 4;

            var item = new UserCartItem
            {
                Price = price,
                Quantity = quantity,
                Cost = price * quantity
            };

            Assert.That(item.Cost, Is.EqualTo(21.00m));
        }

        [Test]
        public void UserCartItem_DefaultCost_IsZero()
        {
            var item = new UserCartItem();

            Assert.That(item.Cost, Is.EqualTo(0));
        }
    }
}
