using System.Windows;
using FoodCalcultorLibrary;
using System.Collections.Generic;

namespace FoodCalculatorGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Food> _foods = new List<Food>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addFoodButton_Click(object sender, RoutedEventArgs e)
        {
            AddFoodWindow addFoodWindow = new AddFoodWindow();
            addFoodWindow.Show();
        }
    }
}