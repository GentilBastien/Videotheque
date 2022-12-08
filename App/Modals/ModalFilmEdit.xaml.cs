using MaVideotheque.DatabaseDataSetTableAdapters;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmEdit : UserControl
    {
        public string Titre { get; set; }

        public long Code_Barre { get; set; }
        public string Synopsis { get; set; }
        public string Acteurs { get; set; }
        public string Realisateur { get; set; }
        public string Langues { get; set; }
        public int Annee { get; set; }
        public int Duree { get; set; }
        public string Genres { get; set; }
        public double Prix { get; set; }
        public string Image { get; set; }
        public ModalFilmEdit(long id, string titre, string realisateur, int duree, int annee, double prix, string image, string synopsis, string genres, string acteurs, string voix, string sous_titres)
        {

            this.Code_Barre = id;
            this.Titre = titre;
            this.Synopsis = synopsis;
            this.Acteurs = acteurs;
            this.Realisateur = realisateur;
            this.Langues = voix + "\n" + sous_titres;
            this.Annee = annee;
            this.Duree = duree;
            this.Genres = genres;
            this.Prix = prix;
            this.Image = image;

            InitializeComponent();
            this.DataContext = this;
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
    }
}
