using DeliveryApp.Models;
using NUnit.Framework;

namespace DeliveryApp.Tests.Models
{
    [TestFixture]
    public class FoodItemTests
    {
        [Test]
        public void FoodItem_SetProperties_RetainsValues()
        {
            var item = new FoodItem
            {
                ProductID = 1,
                Name = "Spaghetti Bolognese",
                Description = "Classic Italian pasta",
                Price = 11.50m,
                CategoryID = 3,
                Rating = "4.5",
                RatingDetail = "120 ratings",
                ImageUrl = "https://example.com/img.jpg",
                HomeSelected = "true"
            };

            Assert.That(item.ProductID, Is.EqualTo(1));
            Assert.That(item.Name, Is.EqualTo("Spaghetti Bolognese"));
            Assert.That(item.Description, Is.EqualTo("Classic Italian pasta"));
            Assert.That(item.Price, Is.EqualTo(11.50m));
            Assert.That(item.CategoryID, Is.EqualTo(3));
            Assert.That(item.Rating, Is.EqualTo("4.5"));
            Assert.That(item.RatingDetail, Is.EqualTo("120 ratings"));
        }

        [Test]
        public void FoodItem_DefaultValues_AreEmpty()
        {
            var item = new FoodItem();

            Assert.That(item.ProductID, Is.EqualTo(0));
            Assert.That(item.Name, Is.Null);
            Assert.That(item.Price, Is.EqualTo(0));
        }
    }
}
