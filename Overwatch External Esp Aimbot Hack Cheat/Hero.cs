using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace hackathon
{
    public class Hero
    {
        private string _first_name;
        private string _last_name;
        private string _ingame_name;
        private string _nationality;
        private string _type;
        private string _age;
        private string _bio;
        BitmapImage pic = new BitmapImage();

        

        public string First_name { get => _first_name; set => _first_name = value; }
        public string Last_name { get => _last_name; set => _last_name = value; }
        public string Ingame_name { get => _ingame_name; set => _ingame_name = value; }
        public string Nationality { get => _nationality; set => _nationality = value; }
        public string Type { get => _type; set => _type = value; }
        public string Age { get => _age; set => _age = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public BitmapImage Pic { get => pic; set => pic = value; }

        public Hero(string pfirst_name, string plast_name, string pingame_name, string pnationality, string ptype, string page, string pbiblio)
        {
            this.First_name = pfirst_name;
            this.Last_name = plast_name;
            this.Ingame_name = pingame_name;
            this.Nationality = pnationality;
            this.Type = ptype;
            this.Age = page;
            this.Bio = pbiblio;
        }

        public override string ToString()
        {
            string tmp = this.Last_name + "#" + this.First_name + "#" + this.Ingame_name + "#" + this.Nationality + "#" + this.Type + "#" + this.Age + "#" + this.Bio + "#";
            return tmp;
        }


    }
}
