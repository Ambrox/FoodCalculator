using NUnit.Framework;
using FoodCalcultorLibrary;

namespace FoodCaculatorLibraryTest
{
    [TestFixture]
    public class FoodTests
    {
        [Test]
        public void FoodConstructor_ShouldCalculateProperValues_PropertiesReturnsProperValues()
        {
            Food food = new Food("Apple", 15, 10, 5, 13, 200);

            Assert.AreEqual("Apple", food.Name);
            Assert.AreEqual(30, food.Calories);
            Assert.AreEqual(20, food.Carbohydrates);
            Assert.AreEqual(10, food.Fat);
            Assert.AreEqual(26, food.Proteins);
            Assert.AreEqual(200, food.Weight);
        }
    }
}