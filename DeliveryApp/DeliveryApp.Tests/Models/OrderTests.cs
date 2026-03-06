using DeliveryApp.Models;
using NUnit.Framework;

namespace DeliveryApp.Tests.Models
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void Order_SetProperties_RetainsValues()
        {
            var order = new Order
            {
                OrderId = "ORD-001",
                Username = "john_doe",
                TotalCost = 45.75m,
                ReceiptId = "REC-XYZ"
            };

            Assert.That(order.OrderId, Is.EqualTo("ORD-001"));
            Assert.That(order.Username, Is.EqualTo("john_doe"));
            Assert.That(order.TotalCost, Is.EqualTo(45.75m));
            Assert.That(order.ReceiptId, Is.EqualTo("REC-XYZ"));
        }

        [Test]
        public void Order_DefaultValues_AreNull()
        {
            var order = new Order();

            Assert.That(order.OrderId, Is.Null);
            Assert.That(order.Username, Is.Null);
            Assert.That(order.TotalCost, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class OrderHistoryTests
    {
        [Test]
        public void OrderHistory_SetProperties_RetainsValues()
        {
            var history = new OrderHistory
            {
                OrderId = "ORD-002",
                Username = "jane_doe",
                TotalCost = 22.00m,
                ReceiptId = "REC-ABC"
            };

            Assert.That(history.OrderId, Is.EqualTo("ORD-002"));
            Assert.That(history.Username, Is.EqualTo("jane_doe"));
            Assert.That(history.TotalCost, Is.EqualTo(22.00m));
            Assert.That(history.ReceiptId, Is.EqualTo("REC-ABC"));
        }

        [Test]
        public void OrderHistory_InheritsFromList_CanAddOrderDetails()
        {
            var history = new OrderHistory();
            var detail = new OrderDetails
            {
                OrderDetailId = "DET-1",
                OrderId = "ORD-002",
                ProductID = 5,
                ProductName = "Fries",
                Price = 3.00m,
                Quantity = 2
            };

            history.Add(detail);

            Assert.That(history.Count, Is.EqualTo(1));
            Assert.That(history[0].ProductName, Is.EqualTo("Fries"));
        }

        [Test]
        public void OrderHistory_IsEmptyByDefault()
        {
            var history = new OrderHistory();

            Assert.That(history.Count, Is.EqualTo(0));
        }
    }
}
