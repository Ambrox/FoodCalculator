using System.Collections.Generic;
using FoodCalcultorLibrary;
using NUnit.Framework;
using Moq;

namespace FoodCaculatorLibraryTest
{
    [TestFixture]
    public class CustomXmlSerializerTests
    {
        private List<Food> _foods = new List<Food>();

        [OneTimeSetUp]
        public void Initialize()
        {
            _foods.Add(new Food("Apple", 15, 10, 5, 13, 100));
            _foods.Add(new Food("Melon", 8, 12, 22, 33, 100));
            _foods.Add(new Food("Orange", 1, 2, 3, 4, 100));
        }

        [Test]
        public void SerializeWithSummary_ShouldSerlizeListOfIFoodObjectsWithSummaryToXml_ReturnsXmlSerializedString()
        {
            CustomXmlSerializer serializer = new CustomXmlSerializer(_foods);
            string result = serializer.SerializeWithSummary();

            Assert.IsTrue(result.Contains("<Name>Apple</Name><Calories>15</Calories><Carbohydrates>10</Carbohydrates><Fat>5</Fat><Proteins>13</Proteins><Weight>100</Weight>"));
            Assert.IsTrue(result.Contains("<Name>Melon</Name><Calories>8</Calories><Carbohydrates>12</Carbohydrates><Fat>22</Fat><Proteins>33</Proteins><Weight>100</Weight>"));
            Assert.IsTrue(result.Contains("<Name>Orange</Name><Calories>1</Calories><Carbohydrates>2</Carbohydrates><Fat>3</Fat><Proteins>4</Proteins><Weight>100</Weight>"));
            Assert.IsTrue(result.Contains("<Summary><Total_Calories>24</Total_Calories><Total_Carbohydrates>24</Total_Carbohydrates><Total_Fat>30</Total_Fat><Total_Proteins>50</Total_Proteins><Total_Weight>300</Total_Weight></Summary>"));
        }

        [Test]
        public void Deserialize_ShouldDeserializeStringToListOfIFoodObjects_PopulatesListWithRightValues()
        {
            List<Food> foods = new List<Food>();

            CustomXmlSerializer serializer = new CustomXmlSerializer(foods);
            serializer.Deserialize("<?xml version=\"1.0\" encoding=\"utf-16\"?><Meal><Ingredient><Name>Apple</Name><Calories>15</Calories><Carbohydrates>10</Carbohydrates><Fat>5</Fat><Proteins>13</Proteins><Weight>100</Weight></Ingredient><Ingredient><Name>Melon</Name><Calories>8</Calories><Carbohydrates>12</Carbohydrates><Fat>22</Fat><Proteins>33</Proteins><Weight>100</Weight></Ingredient><Ingredient><Name>Orange</Name><Calories>1</Calories><Carbohydrates>2</Carbohydrates><Fat>3</Fat><Proteins>4</Proteins><Weight>100</Weight></Ingredient></Meal>");

            Assert.AreEqual(_foods[0].Name, foods[0].Name);
            Assert.AreEqual(_foods[0].Calories, foods[0].Calories);
            Assert.AreEqual(_foods[0].Carbohydrates, foods[0].Carbohydrates);
            Assert.AreEqual(_foods[0].Fat, foods[0].Fat);
            Assert.AreEqual(_foods[0].Proteins, foods[0].Proteins);
            Assert.AreEqual(_foods[0].Weight, foods[0].Weight);

            Assert.AreEqual(_foods[1].Name, foods[1].Name);
            Assert.AreEqual(_foods[1].Calories, foods[1].Calories);
            Assert.AreEqual(_foods[1].Carbohydrates, foods[1].Carbohydrates);
            Assert.AreEqual(_foods[1].Fat, foods[1].Fat);
            Assert.AreEqual(_foods[1].Proteins, foods[1].Proteins);
            Assert.AreEqual(_foods[1].Weight, foods[1].Weight);

            Assert.AreEqual(_foods[2].Name, foods[2].Name);
            Assert.AreEqual(_foods[2].Calories, foods[2].Calories);
            Assert.AreEqual(_foods[2].Carbohydrates, foods[2].Carbohydrates);
            Assert.AreEqual(_foods[2].Fat, foods[2].Fat);
            Assert.AreEqual(_foods[2].Proteins, foods[2].Proteins);
            Assert.AreEqual(_foods[2].Weight, foods[2].Weight);
        }

        [Test]
        public void Serialize_ShouldSerializeListOfIFoodObjectsToXml_ReturnsXmlSerializedString()
        {
            CustomXmlSerializer serializer = new CustomXmlSerializer(_foods);
            string result = serializer.Serialize();

            Assert.IsTrue(result.Contains("<Name>Apple</Name><Calories>15</Calories><Carbohydrates>10</Carbohydrates><Fat>5</Fat><Proteins>13</Proteins><Weight>100</Weight>"));
            Assert.IsTrue(result.Contains("<Name>Melon</Name><Calories>8</Calories><Carbohydrates>12</Carbohydrates><Fat>22</Fat><Proteins>33</Proteins><Weight>100</Weight>"));
            Assert.IsTrue(result.Contains("<Name>Orange</Name><Calories>1</Calories><Carbohydrates>2</Carbohydrates><Fat>3</Fat><Proteins>4</Proteins><Weight>100</Weight>"));
        }
    }
}