using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prb.PizzaOrder.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> pizza = new List<string>();
        string crust;
        string size;
        string pizzaType;
        int pizzaPrice;
        int crustPrice;
        int sizePrice;
        int totaal;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillPizza();
            ckbNormal.IsChecked = true;
            ckbSmall.IsChecked = true;
            lblPrice.Visibility = Visibility.Collapsed;
            btnPay.Visibility = Visibility.Collapsed;
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            getselectedCrust();
            getselectedPizza();
            Calculation();
            lblOverview.Content = $"{size}\n{crust}\n{pizzaType}";
            lblPrice.Visibility = Visibility.Visible;
            btnPay.Visibility = Visibility.Visible;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetWindow();
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Beste klant, bedankt voor uw bestelling!\n" +
                $"\nToeslag Size : € {sizePrice}" +
                $"\nToeslag Type korst: € {crustPrice}" +
                $"\nPizza: € {pizzaPrice}\n" +
                $"\nTotaal Bestelling: € {totaal}", 
                "Ticket", MessageBoxButton.OK, MessageBoxImage.Information);
            ResetWindow();
        }


        private void CkbNormal_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbNormal.IsChecked == true)
            {
                ckbCheesy.IsChecked = false;
            }
        }

        private void CkbCheesy_Checked(object sender, RoutedEventArgs e)
        {
            if(ckbCheesy.IsChecked == true)
            {
                ckbNormal.IsChecked = false;
            }
        }


        private void CkbSmall_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbSmall.IsChecked == true)
            {
                ckbMedium.IsChecked = false;
                ckbLarge.IsChecked = false;
                size = "Size:\n " +
                    "           Small";
            }
        }

        private void CkbMedium_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbMedium.IsChecked == true)
            {
                ckbSmall.IsChecked = false;
                ckbLarge.IsChecked = false;
                size = "Size:\n " +
                    "          Medium";
            }
        }

        private void CkbLarge_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbLarge.IsChecked == true)
            {
                ckbSmall.IsChecked = false;
                ckbMedium.IsChecked = false;
                size = "Size:\n " +
                    "          Large";
            }
        }


        private void getselectedCrust()
        {
           
            if (ckbNormal.IsChecked == true)
            {
                crust = "Crust:\n " +
                    "            normal\n";
            }
            if (ckbCheesy.IsChecked == true)
            {
                crust = "Crust:\n " +
                    "            Cheesy\n";
            }
        }

        private void getselectedPizza()
        {
            if (cmbPizza.SelectedIndex == 0)
            {
                pizzaType = "     Margherita";
            }
            if (cmbPizza.SelectedIndex == 1)
            {
                pizzaType = "     Pepperoni";
            }
            if (cmbPizza.SelectedIndex == 2)
            {
                pizzaType = "     Quatro-Fromaggi";
            }
            if (cmbPizza.SelectedIndex == 3)
            {
                pizzaType = "     Funghi";
            }
        }

        private void FillPizza()
        {
            cmbPizza.Items.Add("Margherita");
            cmbPizza.Items.Add("Pepperoni");
            cmbPizza.Items.Add("Quatro-fromaggi");
            cmbPizza.Items.Add("Funghi");

            cmbPizza.SelectedIndex = 0;
        }

        private void Calculation()
        {
            if (cmbPizza.SelectedIndex == 0)
            {
                pizzaPrice = 8;
            }
            if (cmbPizza.SelectedIndex == 1 || cmbPizza.SelectedIndex == 3)
            {
                pizzaPrice = 10;
            }
            else if (cmbPizza.SelectedIndex == 2)
            {
                pizzaPrice = 15;
            }

            if (ckbSmall.IsChecked == true)
            {
                sizePrice = 0;
            }
            else if (ckbMedium.IsChecked == true)
            {
                sizePrice = 3;
            }
            else if (ckbLarge.IsChecked == true)
            {
                sizePrice = 5;
            }

            if (ckbNormal.IsChecked == true)
            {
                crustPrice = 0;
            }
            else if(ckbCheesy.IsChecked == true)
            {
                crustPrice = 5;
            }

            totaal = crustPrice + pizzaPrice + sizePrice;

            tbkPrice.Text = $"€ {totaal.ToString()}";
        }

        private void ResetWindow()
        {
            lblOverview.Content = null;
            tbkPrice.Text = null;
            cmbPizza.SelectedIndex = 0;
            ckbNormal.IsChecked = true;
            ckbSmall.IsChecked = true;
            lblPrice.Visibility = Visibility.Collapsed;
        }

    }
}
