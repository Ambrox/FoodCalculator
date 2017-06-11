using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace FoodCalcultorLibrary
{
    public class PdfSerializer : DataSerializer
    {
        public PdfSerializer(ObservableCollection<Food> foods) : base(foods)
        {
        }

        public override String Serialize()
        {
            using (StringWriter str = new StringWriter())
            {
                str.WriteLine("Ingredients:");

                foreach (var item in _foods)
                {
                    str.WriteLine("\t-{0}", item.Name);
                    str.WriteLine("\t\t*Calories: {0}", item.Calories);
                    str.WriteLine("\t\t*Carbohydrates: {0}", item.Carbohydrates);
                    str.WriteLine("\t\t*Fat: {0}", item.Fat);
                    str.WriteLine("\t\t*Proteins: {0}", item.Proteins);
                    str.WriteLine("\t\t*Weight: {0}", item.Weight);
                }

                return str.ToString();
            }
        }

        public override string SerializeWithSummary()
        {
            using (StringWriter str = new StringWriter())
            {
                str.WriteLine("Ingredients:");

                foreach (var item in _foods)
                {
                    str.WriteLine("\t-{0}", item.Name);
                    str.WriteLine("\t\t*Calories: {0}", item.Calories);
                    str.WriteLine("\t\t*Carbohydrates: {0}", item.Carbohydrates);
                    str.WriteLine("\t\t*Fat: {0}", item.Fat);
                    str.WriteLine("\t\t*Proteins: {0}", item.Proteins);
                    str.WriteLine("\t\t*Weight: {0}", item.Weight);

                    _totalCalories += item.Calories;
                    _totalCarbohydrates += item.Carbohydrates;
                    _totalFat += item.Fat;
                    _totalProteins += item.Proteins;
                    _totalWeight += item.Weight;
                }

                str.WriteLine("\nSummary:");
                str.WriteLine("\t*Total Calories: {0}", _totalCalories);
                str.WriteLine("\t*Total Carbohydrates: {0}", _totalCarbohydrates);
                str.WriteLine("\t*Total Fat: {0}", _totalFat);
                str.WriteLine("\t*Total Proteins: {0}", _totalProteins);
                str.WriteLine("\t*Total Weight: {0}", _totalWeight);

                return str.ToString();
            }
        }
    }
}