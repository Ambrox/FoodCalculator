using FoodCalcultorLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FoodCalculatorGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Food> Foods = new ObservableCollection<Food>();
        public static ObservableCollection<Food> UserFoods = new ObservableCollection<Food>();
    }
}