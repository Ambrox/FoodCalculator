namespace FoodCalcultorLibrary
{
    public class Food
    {
        public Food(string name, int calories, int carbohydrates, int fat, int proteins, int weight)
        {
            int weightCalc = weight / 100;

            Name = name;
            Calories = calories * weightCalc;
            Carbohydrates = carbohydrates * weightCalc;
            Fat = fat * weightCalc;
            Proteins = proteins * weightCalc;
            Weight = weight;
        }

        public string Name { get; }
        public int Calories { get; }
        public int Carbohydrates { get; }
        public int Fat { get; }
        public int Proteins { get; }
        public int Weight { get; }
    }
}