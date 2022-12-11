using Microsoft.Win32;
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
using System.IO;
using System.Text.RegularExpressions;

namespace hackathon
{
    /// <summary>
    /// Logique d'interaction pour FicheInfo.xaml
    /// </summary>
    public partial class FicheInfo : Window
    {     
        public FicheInfo() // Mode Ajouter
        {
            InitializeComponent();
        }
        private string path = System.AppDomain.CurrentDomain.BaseDirectory;
        private string nomfichier = @"..\..\Hero\liste_heros.txt";
        OpenFileDialog openFile = new OpenFileDialog();
        bool? test;
        int type;
        string temp;
        Hero individu = new Hero("", "", "", "", "", "", "");




        public FicheInfo(Hero selected) // Mode Afficher
        {
            InitializeComponent();
            btnLoadImage.Visibility = System.Windows.Visibility.Hidden;
            btnConfirm.Visibility = System.Windows.Visibility.Hidden;
            btnCancel.Visibility = System.Windows.Visibility.Hidden;
            txtBio.IsEnabled = false;
            txtBFirstName.IsEnabled = false;
            txtBLastName.IsEnabled = false;
            txtBNationality.IsEnabled = false;
            txtBAge.IsEnabled = false;
            cmbox_type.IsEnabled = false;
            txtBInGame.IsEnabled = false;
            txtBInGame.Text = selected.Ingame_name;
            txtBio.Text = selected.Bio;
            txtBFirstName.Text = selected.First_name;
            txtBLastName.Text = selected.Last_name;
            txtBNationality.Text = selected.Nationality;
            txtBAge.Text = selected.Age;
            
            if (selected.Type == "Attack") //attaque
            {
                cmbox_type.SelectedIndex = 0;
            }
            else if (selected.Type == "Defense") //defense
            {
                cmbox_type.SelectedIndex = 1;
            }
            else if (selected.Type == "Tank") //tank
            {
                cmbox_type.SelectedIndex = 2;
            }
            else if (selected.Type == "Support") //support
            {
                cmbox_type.SelectedIndex = 3;
            }

            string _filePath = System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\Hero\" + selected.Ingame_name.ToLower() + ".png";
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(_filePath);
            src.EndInit();
            img.Source = src;
            
        }
        public FicheInfo(Hero selected, bool mod) // Mode Modifier
        {
            
            InitializeComponent();
            btnLoadImage.Visibility = System.Windows.Visibility.Visible;
            btnConfirm.Visibility = System.Windows.Visibility.Visible;
            btnCancel.Visibility = System.Windows.Visibility.Visible;
            txtBio.IsEnabled = true;
            txtBFirstName.IsEnabled = true;
            txtBLastName.IsEnabled = true;
            txtBNationality.IsEnabled = true;
            txtBAge.IsEnabled = true;
            cmbox_type.IsEnabled = true;
            txtBInGame.IsEnabled = true;
            txtBInGame.Text = selected.Ingame_name;
            txtBio.Text = selected.Bio;
            txtBFirstName.Text = selected.First_name;
            txtBLastName.Text = selected.Last_name;
            txtBNationality.Text = selected.Nationality;
            txtBAge.Text = selected.Age;
            temp = txtBInGame.Text;

            if (selected.Type == "Attack") //attaque
            {
                cmbox_type.SelectedIndex = 0;
            }
            else if (selected.Type == "Defense") //defense
            {
                cmbox_type.SelectedIndex = 1;
            }
            else if (selected.Type == "Tank") //tank
            {
                cmbox_type.SelectedIndex = 2;
            }
            else if (selected.Type == "Support") //support
            {
                cmbox_type.SelectedIndex = 3;
            }

            string _filePath = System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\Hero\" + selected.Ingame_name.ToLower() + ".png";
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(_filePath);
            src.EndInit();
            img.Source = src;



        }



        public Hero Individu { get => individu; set => individu = value; }

        public Hero ObtenirHeroIntroduit()
        {
            return this.Individu;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            bool fiche_remplie = true;
            Individu.First_name = txtBFirstName.Text;
            Individu.Last_name = txtBLastName.Text;
            Individu.Ingame_name = txtBInGame.Text; 
            Individu.Nationality = txtBNationality.Text;
            if (cmbox_type.SelectedIndex==0) //attaque
            {
                Individu.Type = "Attack";
            }
            else if (cmbox_type.SelectedIndex == 1) //defense
            {
                Individu.Type = "Defense";
            }
            else if (cmbox_type.SelectedIndex == 2) //tank
            {
                Individu.Type = "Tank";
            }
            else if (cmbox_type.SelectedIndex == 3) //support
            {
                Individu.Type = "Support";
            }
            Individu.Age = txtBAge.Text;
            Individu.Bio = txtBio.Text;

            if (txtBInGame.Text == "")
            {
                fiche_remplie = false;
            }
            else
            {
                if ((test == true || img.Source != null) && txtBInGame.Text != "" && cmbox_type.SelectedIndex !=-1)
                {
                    
                    Regex reg = new Regex(@"[a-zA-Z0-9\-][^""\< \> \: \/ \\\ \| \? \*]");

                    if (reg.IsMatch(txtBInGame.Text))
                    {
                        
                        /*if (Convert.ToString(img.Source) == "")
                        {
                            MessageBox.Show(txtBInGame.Text);
                            System.IO.File.Copy(openFile.FileName, @"..\..\Hero\" + txtBInGame.Text.ToLower() + ".png", true);
                            
                        }*/
                        if(txtBInGame.Text != temp && temp != null)
                        {
                            System.IO.File.Copy(@"..\..\Hero\" + temp.ToLower() + ".png", @"..\..\Hero\" + txtBInGame.Text.ToLower() + ".png", true);
                        }
                        else if(txtBInGame.Text == temp)
                        {
                            
                            
                        }
                        else
                        {
                            System.IO.File.Copy(openFile.FileName, @"..\..\Hero\" + txtBInGame.Text.ToLower() + ".png", true);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Invalid name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        fiche_remplie = false;
                    }
                }
                else
                {
                    fiche_remplie = false;
                }
            }

            if (fiche_remplie == true)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("You must fill in username, image and type.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            openFile.DefaultExt = "mif";
            openFile.Filter = "Fichier PNG (*.png)|*.png";
            test = openFile.ShowDialog();

            //copie le fichier das un dossier de l'app
            if (test == true)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(openFile.FileName, UriKind.Absolute);
                bi3.EndInit();
                img.Stretch = Stretch.Fill;
                img.Source = bi3;
                border_img.Visibility = System.Windows.Visibility.Hidden;
            }
            test = false;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void close(object sender, EventArgs e)
        {

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            
        }

        private void Delete_bad(Hero selecto)
        {
           
        }
    }
}
