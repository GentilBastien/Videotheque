using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace MaVideotheque.Components
{
    public partial class LocationState : UserControl
    {
        public string Couleur { get; set; }
        public int Largeur { get; set; }
        public string Texte { get; set; }
        public LocationState(int mode)
        {
            InitializeComponent();
            this.DataContext = this;

            switch(mode)
            {
                case 0: //rendu
                    this.Couleur = "#54F98C";
                    this.Largeur = 43;
                    this.Texte = "Rendu";
                    break;
                case 1: //en location
                    this.Couleur = "#F98F54";
                    this.Largeur = 65;
                    this.Texte = "En location";
                    break;
                case 2: //en retard
                    this.Couleur = "#F95454";
                    this.Largeur = 56;
                    this.Texte = "En retard";
                    break;
            }
        }

        public static implicit operator string(LocationState v)
        {
            return v.Texte;
        }
    }
}
