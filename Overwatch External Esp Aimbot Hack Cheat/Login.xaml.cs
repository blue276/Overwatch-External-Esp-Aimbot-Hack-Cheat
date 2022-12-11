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
using System.Windows.Shapes;

namespace hackathon
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Pressed(object sender, RoutedEventArgs e)
        {
            string login = txtBLogin.Text;
            string password = txtBPassword.Password.ToString();

            if (login == "SuperUser")
            {
                if (password == "pomme")
                {
                    txtBCor.Text = "Correct";
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong Login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Wrong Login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Fermer(object sender, RoutedEventArgs e)
        {
            string v = txtBCor.Text;
            if (v == "incorrect")
            {
                Environment.Exit(1);
            }           
        }

        private void Fermer(object sender, EventArgs e)
        {
            string v = txtBCor.Text;
            if (v == "incorrect")
            {
                Environment.Exit(1);
            }
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }      
    }
}
