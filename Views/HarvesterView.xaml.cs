using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace rpgProfessionsEasyWay.Views
{
    /// <summary>
    /// Interaction logic for HarvesterView.xaml
    /// </summary>
    public partial class HarvesterView : Window
    {
        private List<string> LISTA_TROPICAL = new List<string>
        {
                "banana",
                "banana",
                "pepper",
                "pepper",
                "black pepper",
                "black pepper",
                "lettuce",
                "lettuce",
                "lime",
                "lime",
                "pineapple",
                "pineapple",
                "sea weed",
                "grape",
                "mikan",
                "green algae",
                "seaking scales",
                "paprika",
                "salt",
                "suggar"
        };
        private List<string> LISTA_MEDIT = new List<string>
        {
                "apple",
                "apple",
                "tomato",
                "tomato",
                "rice",
                "rice",
                "beans",
                "beans",
                "cinammon",
                "cinammon",
                "bay leaves",
                "bay leaves",
                "garlic",
                "carrot",
                "oregano",
                "grounded nuts",
                "corn",
                "mushroom",
                "nuts",
                "mikan"
        };

        private List<string> LISTA_TEMPERATE = new List<string>
        {
            "ginger",
            "ginger",
            "lettuce",
            "lettuce",
            "flour",
            "flour",
            "pumpkin",
            "pumpkin",
            "radish",
            "radish",
            "yam",
            "yam",
            "salt",
            "pumpkin pie spice",
            "bay leafs",
            "mushroom",
            "rice",
            "beans",
            "nuts",
            "grounded nuts"
        };

        private List<string> LISTA_SPECIAL = new List<string>
        {
            "carrots",
            "carrots",
            "potato",
            "potato",
            "mushroom",
            "mushroom",
            "nuts",
            "nuts",
            "tomato",
            "tomato",
            "banana",
            "banana",
            "garlic",
            "cinnamon",
            "ginger",
            "radish",
            "yam",
            "black pepper",
            "grape",
            "corn"
        };

        public HarvesterView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string formatedNumbers = inputNumbers.Text.Replace(" ", "");
            string[] numbers = formatedNumbers.Split(',');

            int[] intNumbers = numbers
                .Where(s => int.TryParse(s, out _)) // Filtrar apenas os elementos que podem ser convertidos em inteiros
                .Select(int.Parse) // Converter os elementos filtrados em inteiros
                .ToArray();

            List<string> listaItens = new List<string>();
            List<string> userSelection = new List<string>();

            if (CheckRadioButtons())
            {
                if (tropical.IsChecked == true)
                    listaItens = LISTA_TROPICAL;
                if (medit.IsChecked == true)
                    listaItens = LISTA_MEDIT;
                if (special.IsChecked == true)
                    listaItens = LISTA_SPECIAL;
                if (temperate.IsChecked == true)
                    listaItens = LISTA_TEMPERATE;

                foreach (var number in intNumbers)
                {
                    if (number > 0 && number <= 20)
                        userSelection.Add(listaItens[number - 1]);
                }

                UpdateTable(userSelection);
            }

        }

        private void UpdateTable(List<string> items)
        {
            tablePanel.Children.Clear();

            foreach (var item in items)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = item,
                    Margin = new Thickness(5),
                    TextWrapping = TextWrapping.Wrap
                };

                tablePanel.Children.Add(textBlock);
            }
        }

        private void ShowErrorMessage(string message)
        {
            alertError.Visibility = Visibility.Visible;
            alertError.Content = message;
        }

        private void ClearErrorMessage()
        {
            alertError.Content = string.Empty;
            alertError.Visibility = Visibility.Hidden;
        }

        private bool CheckRadioButtons()
        {
            if (tropical.IsChecked == false && medit.IsChecked == false &&
                special.IsChecked == false && temperate.IsChecked == false)
            {
                ShowErrorMessage("Please, select one Climate!");
                return false;
            }
            else
            {
                ClearErrorMessage();
                return true;
            }
        }


    }
}
