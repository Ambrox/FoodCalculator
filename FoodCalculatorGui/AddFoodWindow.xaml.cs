using System.Windows;
using System.Windows.Controls;
using FoodCalcultorLibrary;
using System.Collections.Generic;
using System.IO;

namespace FoodCalculatorGui
{
    /// <summary>
    /// Interaction logic for AddFoodWindow.xaml
    /// </summary>
    public partial class AddFoodWindow : Window
    {
        public AddFoodWindow()
        {
            InitializeComponent();
        }

        private void nameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "Name")
                nameTextBox.Text = string.Empty;
        }

        private void nameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == string.Empty)
                nameTextBox.Text = "Name";
        }

        private void caloriesTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (caloriesTextBox.Text == "Calories")
                caloriesTextBox.Text = string.Empty;
        }

        private void caloriesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (caloriesTextBox.Text == string.Empty)
                caloriesTextBox.Text = "Calories";
        }

        private void carbohydratesTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (carbohydratesTextBox.Text == "Carbohydrates")
                carbohydratesTextBox.Text = string.Empty;
        }

        private void carbohydratesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (carbohydratesTextBox.Text == string.Empty)
                carbohydratesTextBox.Text = "Carbohydrates";
        }

        private void fatTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (fatTextBox.Text == "Fat")
                fatTextBox.Text = string.Empty;
        }

        private void fatTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fatTextBox.Text == string.Empty)
                fatTextBox.Text = "Fat";
        }

        private void proteinsTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (proteinsTextBox.Text == "Proteins")
                proteinsTextBox.Text = string.Empty;
        }

        private void proteinsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (proteinsTextBox.Text == string.Empty)
                proteinsTextBox.Text = "Proteins";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(caloriesTextBox.Text, out int calories) && int.TryParse(carbohydratesTextBox.Text, out int carbohydrates) && int.TryParse(fatTextBox.Text, out int fat) && int.TryParse(proteinsTextBox.Text, out int proteins) && int.TryParse(weightTextBox.Text, out int weight))
            {
                App.Foods.Add(new Food(nameTextBox.Text, calories, carbohydrates, fat, proteins, weight));

                CustomXmlSerializer serializer = new CustomXmlSerializer(App.Foods);
                string output = serializer.Serialize();

                File.WriteAllText("FoodDatabase.xml", output);
            }
            else
                MessageBox.Show("Please input correct data");
        }
    }
}