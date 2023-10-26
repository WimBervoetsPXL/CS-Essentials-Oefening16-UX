using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Oefening16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBereken_Click(object sender, RoutedEventArgs e)
        {
            BerekenMachtEnToonResultaat();
        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Clear();
            TxtGetal.Text = "1";
            TxtGetal.Focus();
            TxtGetal.SelectAll();
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtGetal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                BerekenMachtEnToonResultaat();
                e.Handled = true;
            }
        }

        private void TxtGetal_KeyUp(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0 && !int.TryParse(TxtGetal.Text, out _))
            {
                ((TextBox)sender).Background = Brushes.Coral; 
            }
            else
            {
                ((TextBox)sender).Background = Brushes.White;
            }
        }

        private void BerekenMachtEnToonResultaat()
        {
            if (int.TryParse(TxtGetal.Text, out int value))
            {
                if (value <= 84)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 1; i <= 10; i++)
                    {
                        sb.AppendLine($"Macht {i} van {value} is {Math.Pow(value, i):N0}");
                    }

                    TxtResultaat.Text = sb.ToString();
                }
                else
                {
                    MessageBox.Show("Getal moet kleiner zijn dan 85.");
                }
            }
            else
            {
                MessageBox.Show("Dit is geen geldig getal.");
            }

            TxtGetal.Focus();
            TxtGetal.SelectAll();
        }

 
    }
}
