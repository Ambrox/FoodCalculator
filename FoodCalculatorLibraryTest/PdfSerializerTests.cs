using System.Collections.Generic;
using FoodCalcultorLibrary;
using Moq;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace FoodCaculatorTest
{
    [TestFixture]
    public class PdfSerializerLibraryTests
    {
        private ObservableCollection<Food> _foods = new ObservableCollection<Food>();

        [OneTimeSetUp]
        public void Initialize()
        {
            _foods.Add(new Food("Apple", 15, 10, 5, 13, 100));
            _foods.Add(new Food("Melon", 8, 12, 22, 33, 100));
            _foods.Add(new Food("Orange", 1, 2, 3, 4, 100));
        }

        [Test]
        public void SerializeWithSummary_ShouldSerializeListOfIFoodObjestsWithSummaryToPdf_ReturnsPdfSerializedString()
        {
            PdfSerializer serializer = new PdfSerializer(_foods);
            string expectedResult = "Ingredients:\r\n\t-Apple\r\n\t\t*Calories: 15\r\n\t\t*Carbohydrates: 10\r\n\t\t*Fat: 5\r\n\t\t*Proteins: 13\r\n\t\t*Weight: 100";
            expectedResult += "\r\n\t-Melon\r\n\t\t*Calories: 8\r\n\t\t*Carbohydrates: 12\r\n\t\t*Fat: 22\r\n\t\t*Proteins: 33\r\n\t\t*Weight: 100";
            expectedResult += "\r\n\t-Orange\r\n\t\t*Calories: 1\r\n\t\t*Carbohydrates: 2\r\n\t\t*Fat: 3\r\n\t\t*Proteins: 4\r\n\t\t*Weight: 100";
            expectedResult += "\r\n\nSummary:\r\n\t*Total Calories: 24\r\n\t*Total Carbohydrates: 24\r\n\t*Total Fat: 30\r\n\t*Total Proteins: 50\r\n\t*Total Weight: 300\r\n";

            string result = serializer.SerializeWithSummary();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Serialize_ShouldSerializeListOfIFoodObjestsToPdf_ReturnsPdfSerializedString()
        {
            PdfSerializer serializer = new PdfSerializer(_foods);
            string expectedResult = "Ingredients:\r\n\t-Apple\r\n\t\t*Calories: 15\r\n\t\t*Carbohydrates: 10\r\n\t\t*Fat: 5\r\n\t\t*Proteins: 13\r\n\t\t*Weight: 100";
            expectedResult += "\r\n\t-Melon\r\n\t\t*Calories: 8\r\n\t\t*Carbohydrates: 12\r\n\t\t*Fat: 22\r\n\t\t*Proteins: 33\r\n\t\t*Weight: 100";
            expectedResult += "\r\n\t-Orange\r\n\t\t*Calories: 1\r\n\t\t*Carbohydrates: 2\r\n\t\t*Fat: 3\r\n\t\t*Proteins: 4\r\n\t\t*Weight: 100\r\n";

            string result = serializer.Serialize();

            Assert.AreEqual(expectedResult, result);
        }
    }
}