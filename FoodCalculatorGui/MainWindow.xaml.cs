using System.Windows;
using FoodCalcultorLibrary;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

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

        private void exportToPdfButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pdf files(*.pdf) | *.pdf";
            if (saveFileDialog.ShowDialog() == true)
            {
                PdfSerializer serializer = new PdfSerializer(App.UserFoods);
                string result = serializer.SerializeWithSummary();
                string[] lines = result.Split('\n');

                PdfDocument document = new PdfDocument();
                document.Info.Title = saveFileDialog.SafeFileName;

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Verdana", 10, XFontStyle.BoldItalic);

                int i = 0;
                foreach (string line in lines)
                {
                    gfx.DrawString(line, font, XBrushes.Black,
                        new XRect(0, 0 + i, page.Width, page.Height),
                        XStringFormats.TopLeft);
                    i += 10;
                }

                document.Save(saveFileDialog.FileName);
            }
        }

        private void exportToXmlButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml files(*.xml) | *.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                CustomXmlSerializer serialize = new CustomXmlSerializer(App.UserFoods);
                string result = serialize.SerializeWithSummary();
                File.WriteAllText(saveFileDialog.FileName, result);
            }
        }
    }
}