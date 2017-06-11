using System.Windows;
using FoodCalcultorLibrary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.IO;

namespace FoodCalculatorGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string xmlFile = File.ReadAllText("FoodDatabase.xml");
            CustomXmlSerializer serializer = new CustomXmlSerializer(App.Foods);
            serializer.Deserialize(xmlFile);

            listBoxFood.ItemsSource = App.Foods;
            userFoodListView.ItemsSource = App.UserFoods;
        }

        private void addFoodButton_Click(object sender, RoutedEventArgs e)
        {
            AddFoodWindow addFoodWindow = new AddFoodWindow();
            addFoodWindow.Show();
        }

        private void listBoxFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxFood.SelectedItem != null)
            {
                Food food = listBoxFood.SelectedItem as Food;

                nameTextBox.Text = food.Name;
                weightTextBox.Text = food.Weight.ToString();
                caloriesTextBox.Text = food.Calories.ToString();
                carbohydratesTextBox.Text = food.Carbohydrates.ToString();
                fatTextBox.Text = food.Fat.ToString();
                proteinsTextBox.Text = food.Proteins.ToString();

                addButton.IsEnabled = true;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            App.UserFoods.Add(new Food(nameTextBox.Text, int.Parse(caloriesTextBox.Text), int.Parse(carbohydratesTextBox.Text), int.Parse(fatTextBox.Text), int.Parse(proteinsTextBox.Text), int.Parse(weightTextBox.Text)));

            caloriesTotalLabel.Content = (int.Parse(caloriesTotalLabel.Content.ToString()) + int.Parse(caloriesTextBox.Text));
            carbohydratesTotalLabel.Content = (int.Parse(carbohydratesTotalLabel.Content.ToString()) + int.Parse(carbohydratesTextBox.Text));
            fatTotalLabel.Content = (int.Parse(fatTotalLabel.Content.ToString()) + int.Parse(fatTextBox.Text));
            proteinsTotalLabel.Content = (int.Parse(proteinsTotalLabel.Content.ToString()) + int.Parse(proteinsTextBox.Text));
            weightTotalLabel.Content = (int.Parse(weightTotalLabel.Content.ToString()) + int.Parse(weightTextBox.Text));
        }

        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (userFoodListView.SelectedItem != null)
            {
                App.UserFoods.RemoveAt(userFoodListView.SelectedIndex);
            }
        }

        private void userFoodListView_GotFocus(object sender, RoutedEventArgs e)
        {
            deleteItemButton.IsEnabled = true;
        }
    }
}