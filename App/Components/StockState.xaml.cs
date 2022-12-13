using System.Windows.Controls;

namespace MaVideotheque.Components
{
    public partial class StockState : UserControl
    {
        public string Couleur { get; set; }
        public int Largeur { get; set; }
        public string Texte { get; set; }
        public StockState(int mode)
        {
            InitializeComponent();
            this.DataContext = this;

            switch (mode)
            {
                case 0: //en rayon
                    this.Couleur = "#54F98C";
                    this.Largeur = 60;
                    this.Texte = "En rayon";
                    break;
                case 1: //commandés
                    this.Couleur = "#F98F54";
                    this.Largeur = 60;
                    this.Texte = "Commandés";
                    break;
                case 2: //rupture stock
                    this.Couleur = "#F95454";
                    this.Largeur = 60;
                    this.Texte = "Rupture";
                    break;
                case 3: //vide, utile pour les commandes ?
                    this.Couleur = "white";
                    this.Largeur = 0;
                    this.Texte = "";
                    break;
            }
        }
    }
}
