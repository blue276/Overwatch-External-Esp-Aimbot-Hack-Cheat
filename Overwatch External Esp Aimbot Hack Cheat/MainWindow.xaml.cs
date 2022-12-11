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
using System.Collections.ObjectModel;//Pour l'Observable Collection
using System.IO;

namespace hackathon
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = listing;
        }

        bool first_launch = false;
        ObservableCollection<Hero> listing = new ObservableCollection<Hero>();
        private string path = System.AppDomain.CurrentDomain.BaseDirectory;
        private string nomfichier = @"..\..\Hero\liste_heros.txt";
        string text2;
        public string hero;

        private void size(object sender, SizeChangedEventArgs e)
        {
            main_window.Height = main_window.Width / 1.7;
        }

        public void Lecture_Liste_heros(object sender, RoutedEventArgs e)
        {
            if (first_launch == false)
            {
                Login log = new Login();
                log.ShowDialog();
                first_launch = true;
            }
            listing.Clear();
            StreamReader lecteur = new StreamReader(path + nomfichier);
            while (!lecteur.EndOfStream)
            {
                string tmp = lecteur.ReadLine();
                string[] tmp2;
                tmp2 = tmp.Split('#');
                listing.Add(new Hero(tmp2[1], tmp2[2], tmp2[0], tmp2[3], tmp2[5], tmp2[4], tmp2[6]));
            }
            lecteur.Close();
        }

        private void show(object sender, RoutedEventArgs e)
        {
            if (datagrid1.SelectedItems.Count == 1)
            {
                string select = datagrid1.SelectedItem.ToString();
                string [] text;
                Hero selected = new Hero("", "", "", "", "", "", "");
                for (int i = 0; i < 3; i++)
                {
                    text = select.Split('#');
                    text2 = text[i].ToString(); ;
                }
                hero = text2;

                foreach (Hero item in datagrid1.SelectedItems)
                {
                    selected = item;
                }
                Save_show();
                FicheInfo window = new FicheInfo(selected);
                window.ShowDialog();
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            FicheInfo fenetre = new FicheInfo();

            if ((bool)fenetre.ShowDialog())
            {
                listing.Add(fenetre.ObtenirHeroIntroduit());
            }
        }

        private void Attack(object sender, RoutedEventArgs e)
        {
            if (chkBAttack.IsChecked == true)
            {
                chkBDef.IsChecked = false;
                chkBSup.IsChecked = false;
                chkBTank.IsChecked = false;
                listing.Clear();
                StreamReader lecteur = new StreamReader(path + nomfichier);
                while (!lecteur.EndOfStream)
                {
                    string tmp = lecteur.ReadLine();
                    string[] tmp2;
                    tmp2 = tmp.Split('#');
                    if (tmp2[5] == "Attack")
                    {
                        listing.Add(new Hero(tmp2[1], tmp2[2], tmp2[0], tmp2[3], tmp2[5], tmp2[4], tmp2[6]));
                    }
                }
                lecteur.Close();
            }
        }

        private void Defence(object sender, RoutedEventArgs e)
        {
            if (chkBDef.IsChecked == true)
            {
                chkBAttack.IsChecked= false;
                chkBSup.IsChecked = false;
                chkBTank.IsChecked = false;
                listing.Clear();
                StreamReader lecteur = new StreamReader(path + nomfichier);
                while (!lecteur.EndOfStream)
                {
                    string tmp = lecteur.ReadLine();
                    string[] tmp2;
                    tmp2 = tmp.Split('#');
                    if (tmp2[5] == "Defense")
                    {
                        listing.Add(new Hero(tmp2[1], tmp2[2], tmp2[0], tmp2[3], tmp2[5], tmp2[4], tmp2[6]));
                    }
                }
                lecteur.Close();
            }
        }

        private void Tank(object sender, RoutedEventArgs e)
        {
            if (chkBTank.IsChecked == true)
            {
                chkBDef.IsChecked = false;
                chkBSup.IsChecked = false;
                chkBAttack.IsChecked = false;
                listing.Clear();
                StreamReader lecteur = new StreamReader(path + nomfichier);
                while (!lecteur.EndOfStream)
                {
                    string tmp = lecteur.ReadLine();
                    string[] tmp2;
                    tmp2 = tmp.Split('#');
                    if (tmp2[5] == "Tank")
                    {
                        listing.Add(new Hero(tmp2[1], tmp2[2], tmp2[0], tmp2[3], tmp2[5], tmp2[4], tmp2[6]));
                    }
                }
                lecteur.Close();
            }
        }

        private void Support(object sender, RoutedEventArgs e)
        {
            if (chkBSup.IsChecked == true)
            {
                chkBDef.IsChecked = false;
                chkBAttack.IsChecked = false;
                chkBTank.IsChecked = false;
                listing.Clear();
                StreamReader lecteur = new StreamReader(path + nomfichier);
                while (!lecteur.EndOfStream)
                {
                    string tmp = lecteur.ReadLine();
                    string[] tmp2;
                    tmp2 = tmp.Split('#');
                    if (tmp2[5] == "Support")
                    {
                        listing.Add(new Hero(tmp2[1], tmp2[2], tmp2[0], tmp2[3], tmp2[5], tmp2[4], tmp2[6]));
                    }
                }
                lecteur.Close();
            }
        }

        private void Ajouter_hero(object sender, RoutedEventArgs e)
        {
            FicheInfo windowadd = new FicheInfo();
            
        }

        private void Save(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save ?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question);
            chkBAttack.IsChecked = false;
            chkBDef.IsChecked = false;
            chkBSup.IsChecked = false;
            chkBTank.IsChecked = false;
            if (result == MessageBoxResult.Yes)
            {
                StreamWriter save = new StreamWriter(path + nomfichier);
                foreach (var line in listing)
                {
                    save.WriteLine(line.Ingame_name + "#" + line.First_name + "#" + line.Last_name + "#" + line.Nationality + "#" + line.Age + "#" + line.Type + "#" + line.Bio + "#");
                }
                save.Close();
            }

        }

        private void Save_show()
        {
            chkBAttack.IsChecked = false;
            chkBDef.IsChecked = false;
            chkBSup.IsChecked = false;
            chkBTank.IsChecked = false;
            StreamWriter save = new StreamWriter(path + nomfichier);
            foreach (var line in listing)
            {
                save.WriteLine(line.Ingame_name + "#" + line.First_name + "#" + line.Last_name + "#" + line.Nationality + "#" + line.Age + "#" + line.Type + "#" + line.Bio + "#");
            }
            save.Close();
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

            DataGrid DG = datagrid1;

            if ((DG.SelectedItems.Count == 1) && (DG != null))
            {
                Hero hero = new Hero("", "", "", "", "", "", "");
                foreach (var row in DG.SelectedItems)
                {
                    hero = (Hero)row;
                }
                FicheInfo fenetre = new FicheInfo(hero, true);
                

                if (fenetre.ShowDialog() == true)
                {
                    Hero tmp = new Hero("", "", "", "", "", "", "");
                    tmp = fenetre.Individu;
                    listing.Remove(hero);
                    listing.Add(tmp);
                }



            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataGrid DG = datagrid1;

            if (DG.SelectedItems.Count == 0 || DG ==null)
            {
                MessageBox.Show("Select a Hero first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("Are you sure to delete the selected content ?", "Delete file", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Hero hero = new Hero("", "", "", "", "", "", "");
                    foreach (var row in DG.SelectedItems)
                    {
                        hero = (Hero)row;
                    }
                    listing.Remove(hero);
                }
                

            }
        }
        
    }
}
