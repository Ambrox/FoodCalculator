using System.Windows;
using FoodCalcultorLibrary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FoodCalculatorGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Food> _foods = new ObservableCollection<Food>();
        private ObservableCollection<Food> _userFoods = new ObservableCollection<Food>();

        public MainWindow()
        {
            InitializeComponent();

            _foods.Add(new Food("Apple", 10, 23, 5, 12, 100));
            _foods.Add(new Food("Orange", 10, 23, 5, 12, 100));
            _foods.Add(new Food("Melon", 10, 23, 5, 12, 100));

            listBoxFood.ItemsSource = _foods;
            userFoodListView.ItemsSource = _userFoods;
        }

        private void addFoodButton_Click(object sender, RoutedEventArgs e)
        {
            AddFoodWindow addFoodWindow = new AddFoodWindow();
            addFoodWindow.Show();
        }

        private void listBoxFood_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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
            _userFoods.Add(new Food(nameTextBox.Text, int.Parse(caloriesTextBox.Text), int.Parse(carbohydratesTextBox.Text), int.Parse(fatTextBox.Text), int.Parse(proteinsTextBox.Text), int.Parse(weightTextBox.Text)));

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
                _userFoods.RemoveAt(userFoodListView.SelectedIndex);
            }
        }

        private void userFoodListView_GotFocus(object sender, RoutedEventArgs e)
        {
            deleteItemButton.IsEnabled = true;
        }
    }
}