using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Linq;
using MaVideotheque.Views;
using MaVideotheque.Components;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmCopies : UserControl
    {
        //film à modifier
        public Film monFilm;

        //Les attributs suivants sont en DataBinding direct avec la vue (modale)
        public int? NbStock { get; set; }
        public int? NbPret { get; set; }
        public int? NbCommande { get; set; }

        //La FilmView ayant appelé la modale
        public FilmView fv = null;
        public ModalFilmCopies(Film film)
        {
            InitializeComponent();
            this.DataContext = this;
            //On remplit les 2 champs en initialisant ces attributs
            this.NbStock = film.stock_total;
            this.NbPret = film.exemplaires_loues;
            this.NbCommande = film.commandes;
            //on initialise l'attribut monFilm
            this.monFilm = film;
        }
        private void ClicAilleurs(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        //On lie la FilmView à la modale
        public void SetFilmView(object parent)
        {
            this.fv = parent as FilmView; // on stocke le parent actuel
        }

        //Lors du clic sur valider
        private void ValidateButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //On récupère les 3 inputs
            this.NbStock = int.Parse(InputStock.Text);
            this.NbPret = int.Parse(InputPret.Text);
            this.NbCommande = int.Parse(InputCommande.Text);

            //On modifie la BDD en conséquence
            SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING);
            string queryCopies = "UPDATE Films SET stock_total = " + this.NbStock + ",exemplaires_loues = " + this.NbPret + ",commandes = " + this.NbCommande + "WHERE code_barre=" + this.monFilm.code_barre;
            SqlCommand command = conn.CreateCommand();
            command.CommandText = queryCopies;
            try
            { 
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                this.Visibility = Visibility.Collapsed;
            }
            finally
            {
                conn.Close();
            }

            monFilm.stock_total = (int)NbStock;
            monFilm.exemplaires_loues = (int)NbPret;
            monFilm.commandes = (int)NbCommande;

            fv.InitFilms();
            fv.UpdateSelectedFilm(this.monFilm.code_barre);

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
