using System.Windows;
using System.Windows.Controls;

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

        private void weightTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (weightTextBox.Text == "Weight(g)")
                weightTextBox.Text = string.Empty;
        }

        private void weightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (weightTextBox.Text == string.Empty)
                weightTextBox.Text = "Weight(g)";
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
        }
    }
}