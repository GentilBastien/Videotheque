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
        public Film monFilm;
        public long? id;
        public int? NbStock { get; set; }
        public int? NbPret { get; set; }
        public int? NbCommande { get; set; }
        public FilmView fv = null;
        public ModalFilmCopies(Film film)
        {
            InitializeComponent();
            this.DataContext = this;
            this.NbStock = film.stock_total;
            this.NbPret = film.exemplaires_loues;
            this.NbCommande = film.commandes;
            this.id = film.code_barre;
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

        public void GetFilmView(object parent)
        {
            this.fv = parent as FilmView; // on stocke le parent actuel
        }

        private void ValidateButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NbStock = int.Parse(InputStock.Text);
            this.NbPret = int.Parse(InputPret.Text);
            this.NbCommande = int.Parse(InputCommande.Text);

            String ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fbelh\source\repos\Videotheque\App\Database.mdf; Integrated Security = True; Connect Timeout = 30";
            DataContext db = new DataContext(ConnectionString);

            SqlConnection conn = new SqlConnection(ConnectionString);
            string queryCopies = "UPDATE Films SET stock_total = "+this.NbStock+",exemplaires_loues = "+this.NbPret+",commandes = "+this.NbCommande+"WHERE code_barre="+this.id;

            SqlCommand command = conn.CreateCommand();
            command.CommandText = queryCopies;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            db.SubmitChanges();
            
            this.Visibility = Visibility.Collapsed;

            fv.ReloadFilmsCopies(this.monFilm,this.NbStock,this.NbPret,this.NbCommande);
            fv.UpdateSelectedFilm(this.id);
            
            
        }

        private void BtnCommandes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.NbStock += this.NbCommande;
            //this.NbCommande = 0;
            //InputStock.Text = this.NbStock.ToString();
            //InputCommande.Text = this.NbCommande.ToString();
        }
    }
}
