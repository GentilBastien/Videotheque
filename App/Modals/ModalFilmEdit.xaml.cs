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
        public string Voix { get; set; }
        public string Sous_titres { get; set; }
        public int? Annee { get; set; }
        public int? Duree { get; set; }
        public string Genres { get; set; }
        public double? Prix { get; set; }
        public string Image { get; set; }
        public ModalFilmEdit(Film film)
        {

            this.Code_Barre = film.code_barre;
            this.Titre = film.titre;
            this.Synopsis = film.synopsis;
            this.Acteurs = "";
            for (int i = 0; i < film.Roles.Count; i++)
            {
                this.Acteurs += film.Roles.ElementAt(i).Acteur.nom+ ";";
            }
            this.Realisateur = film.Realisateur1.nom;
            this.Voix = "";
            for(int i = 0; i<film.Voixes.Count; i++)
            {
                this.Voix += film.Voixes.ElementAt(i).Langue.langue1+";";
            }

            this.Sous_titres = "";
            for (int i = 0; i < film.Sous_titrages.Count; i++)
            {
                this.Sous_titres += film.Sous_titrages.ElementAt(i).Langue.langue1 + ";";
            }
            this.Annee = film.annee;
            this.Duree = film.duree;
            this.Genres = "";
            for (int i = 0; i < film.Classifications.Count; i++)
            {
                this.Genres += film.Classifications.ElementAt(i).Genre.nom + ";";
            }
            this.Prix = film.prix;
            this.Image = film.image;

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
            //this.Code_Barre = int.Parse(InputCodeBarre.Text);
            this.Titre = InputFilmname.Text;
            this.Visibility = Visibility.Collapsed;
        }
    }
}
