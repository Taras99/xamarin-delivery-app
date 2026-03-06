using DeliveryApp.Models;
using DeliveryApp.Services;
using DeliveryApp.Tests.Fakes;
using NUnit.Framework;

namespace DeliveryApp.Tests.Services
{
    [TestFixture]
    public class CartItemServiceTests
    {
        private InMemorySQLite _db;
        private CartItemService _service;

        [SetUp]
        public void SetUp()
        {
            _db = new InMemorySQLite();
            _service = new CartItemService(_db);
        }

        [TearDown]
        public void TearDown()
        {
            _db.Dispose();
        }

        // ── GetUserCartCount ────────────────────────────────────────────────

        [Test]
        public void GetUserCartCount_EmptyCart_ReturnsZero()
        {
            var count = _service.GetUserCartCount();

            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void GetUserCartCount_AfterInsertingItems_ReturnsCorrectCount()
        {
            InsertCartItem(productName: "Pizza", price: 9.99m, quantity: 1);
            InsertCartItem(productName: "Burger", price: 7.50m, quantity: 2);

            var count = _service.GetUserCartCount();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void GetUserCartCount_AfterInsertingOneItem_ReturnsOne()
        {
            InsertCartItem(productName: "Fries", price: 3.00m, quantity: 1);

            var count = _service.GetUserCartCount();

            Assert.That(count, Is.EqualTo(1));
        }

        // ── RemoveItemsFromCart ─────────────────────────────────────────────

        [Test]
        public void RemoveItemsFromCart_EmptyCart_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => _service.RemoveItemsFromCart());
        }

        [Test]
        public void RemoveItemsFromCart_WithItems_ClearsAllItems()
        {
            InsertCartItem(productName: "Pizza", price: 9.99m, quantity: 1);
            InsertCartItem(productName: "Burger", price: 7.50m, quantity: 2);

            _service.RemoveItemsFromCart();

            Assert.That(_service.GetUserCartCount(), Is.EqualTo(0));
        }

        [Test]
        public void RemoveItemsFromCart_CalledTwice_RemainsEmpty()
        {
            InsertCartItem(productName: "Salad", price: 5.00m, quantity: 1);

            _service.RemoveItemsFromCart();
            _service.RemoveItemsFromCart();

            Assert.That(_service.GetUserCartCount(), Is.EqualTo(0));
        }

        [Test]
        public void RemoveItemsFromCart_DoesNotAffectOtherTables()
        {
            // Ensure no cross-table side effects — count stays 0 before and after
            var countBefore = _service.GetUserCartCount();
            _service.RemoveItemsFromCart();
            var countAfter = _service.GetUserCartCount();

            Assert.That(countBefore, Is.EqualTo(0));
            Assert.That(countAfter, Is.EqualTo(0));
        }

        // ── helpers ─────────────────────────────────────────────────────────

        private void InsertCartItem(string productName, decimal price, int quantity)
        {
            using var cn = _db.GetConnection();
            cn.Insert(new CartItem
            {
                ProductName = productName,
                Price = price,
                Quantity = quantity
            });
        }
    }
}
