using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmCopies : UserControl
    {
        public int NbStock { get; set; }
        public int NbPret { get; set; }
        public int NbCommande { get; set; }
        public ModalFilmCopies(int nbStock, int nbPret, int nbCommande)
        {
            InitializeComponent();
            this.DataContext = this;

            this.NbStock = nbStock;
            this.NbPret = nbPret;
            this.NbCommande = nbCommande;
        }
        private void ClicAilleurs(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ValidateButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void BtnCommandes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NbStock += this.NbCommande;
            this.NbCommande = 0;
            InputStock.Text = this.NbStock.ToString();
            InputCommande.Text = this.NbCommande.ToString();
        }
    }
}
