using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace FoodCalcultorLibrary
{
    public class CustomXmlSerializer : DataSerializer
    {
        public CustomXmlSerializer(List<Food> foods) : base(foods)
        {
        }

        public override string Serialize()
        {
            using (StringWriter str = new StringWriter())
            {
                using (XmlWriter xml = XmlWriter.Create(str))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("Meal");

                    foreach (var item in _foods)
                    {
                        xml.WriteStartElement("Ingredient");

                        xml.WriteElementString("Name", item.Name);
                        xml.WriteElementString("Calories", item.Calories.ToString());
                        xml.WriteElementString("Carbohydrates", item.Carbohydrates.ToString());
                        xml.WriteElementString("Fat", item.Fat.ToString());
                        xml.WriteElementString("Proteins", item.Proteins.ToString());
                        xml.WriteElementString("Weight", item.Weight.ToString());

                        xml.WriteEndElement();
                    }

                    xml.WriteEndElement();
                    xml.WriteEndDocument();
                }
                return str.ToString();
            }
        }

        public override string SerializeWithSummary()
        {
            using (StringWriter str = new StringWriter())
            {
                using (XmlWriter xml = XmlWriter.Create(str))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("Meal");

                    foreach (var item in _foods)
                    {
                        xml.WriteStartElement("Ingredient");

                        xml.WriteElementString("Name", item.Name);
                        xml.WriteElementString("Calories", item.Calories.ToString());
                        xml.WriteElementString("Carbohydrates", item.Carbohydrates.ToString());
                        xml.WriteElementString("Fat", item.Fat.ToString());
                        xml.WriteElementString("Proteins", item.Proteins.ToString());
                        xml.WriteElementString("Weight", item.Weight.ToString());

                        xml.WriteEndElement();

                        _totalCalories += item.Calories;
                        _totalCarbohydrates += item.Carbohydrates;
                        _totalFat += item.Fat;
                        _totalProteins += item.Proteins;
                        _totalWeight += item.Weight;
                    }

                    xml.WriteStartElement("Summary");

                    xml.WriteElementString("Total_Calories", _totalCalories.ToString());
                    xml.WriteElementString("Total_Carbohydrates", _totalCarbohydrates.ToString());
                    xml.WriteElementString("Total_Fat", _totalFat.ToString());
                    xml.WriteElementString("Total_Proteins", _totalProteins.ToString());
                    xml.WriteElementString("Total_Weight", _totalWeight.ToString());

                    xml.WriteEndElement();

                    xml.WriteEndElement();
                    xml.WriteEndDocument();
                }
                return str.ToString();
            }
        }

        public void Deserialize(string s)
        {
            using (StringReader sr = new StringReader(s))
            {
                using (XmlReader reader = XmlReader.Create(sr))
                {
                    string name = string.Empty;
                    int calories = -1, carbohydrates = -1, fat = -1, proteins = -1, weight = -1;
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "Ingredient":
                                    break;

                                case "Name":
                                    name = reader.ReadString();
                                    break;

                                case "Calories":
                                    calories = int.Parse(reader.ReadString());
                                    break;

                                case "Carbohydrates":
                                    carbohydrates = int.Parse(reader.ReadString());
                                    break;

                                case "Fat":
                                    fat = int.Parse(reader.ReadString());
                                    break;

                                case "Proteins":
                                    proteins = int.Parse(reader.ReadString());
                                    break;

                                case "Weight":
                                    weight = int.Parse(reader.ReadString());
                                    if (name != string.Empty && calories != -1 && carbohydrates != -1 && fat != -1 && proteins != -1 && weight != -1)
                                    {
                                        _foods.Add(new Food(name, calories, carbohydrates, fat, proteins, weight));
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}