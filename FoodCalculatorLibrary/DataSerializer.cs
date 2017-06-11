using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FoodCalcultorLibrary
{
    public abstract class DataSerializer
    {
        protected ObservableCollection<Food> _foods;
        protected int _totalCalories = 0;
        protected int _totalCarbohydrates = 0;
        protected int _totalFat = 0;
        protected int _totalProteins = 0;
        protected int _totalWeight = 0;

        protected DataSerializer(ObservableCollection<Food> foods)
        {
            _foods = foods;
        }

        public abstract string Serialize();

        public abstract string SerializeWithSummary();
    }
}