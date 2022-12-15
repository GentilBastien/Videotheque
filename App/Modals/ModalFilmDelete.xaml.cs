
using MaVideotheque.Views;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataContext = System.Data.Linq.DataContext;
using UserControl = System.Windows.Controls.UserControl;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmDelete : UserControl
    {
        //Le message affiché dans la modale
        public string Msg { get; set; }
        //Le film à supprimer
        public Film monFilm { get; set; }
        //La FilmView ayant appelé la modale
        public FilmView fv { get; set; }

        public ModalFilmDelete(Film film)
        {
            InitializeComponent();
            this.DataContext = this;

            //On initialise nos deux objets
            this.monFilm = film;
            this.Msg = "Êtes-vous sûr de vouloir supprimer " + film.titre + " de la liste des films ?";

            //Le troisième est initialisé à l'appel de la méthode SetFilmView depuis l'extérieur
            this.fv = null;
        }
      
        //Permet de lier la modale à la FilmView
        public void SetFilmView(object parent)
        {
            this.fv = parent as FilmView; // on stocke le parent actuel
        }


        private void ClicAilleurs(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        //Si l'on clique sur valider
        private void ValidateButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //On utilise la connection string statique
            
            SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING);

            //On stocke les querys dans un array
            //Nous sommes obligés d'en faire 5
            //car nous n'avons pas activé la suppression
            //en cascade lors de la définition du scéma de bdd
            string[] querysDelete = {"delete from Classifications where id_film="+this.monFilm.code_barre,
            "delete from Roles where id_film="+this.monFilm.code_barre,
            "delete from Voix where id_film="+this.monFilm.code_barre,
            "delete from Sous_titrages where id_film="+this.monFilm.code_barre,
            "delete from Locations where id_film="+this.monFilm.code_barre,
            "delete from Films where code_barre="+this.monFilm.code_barre };

            //On exécute tour à tour les querys
            for (int i = 0; i < querysDelete.Length; i++)
            {
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = querysDelete[i];
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }

            //On parcourt notre objet ALL_LOCATIONS, et on supprime tous les objets
            //Location qui portaient sur le film
            var queryloc = (from location in LocationView.ALL_LOCATIONS where location.id_film == monFilm.code_barre select location).ToList();
            if (queryloc.Any())
            {
                foreach (Location loc in queryloc)
                {
                    LocationView.ALL_LOCATIONS.Remove(loc);
                }
            }
            

            //On parcourt notre objet ALL_CLIENTS, et on supprime tous les objets
            //Location qui portaient sur le film
            var querycli = (from client in ClientView.ALL_CLIENTS select client).ToList();
            if (querycli.Any())
            {
                foreach (Client cli in querycli)
                {
                    if (cli.Locations.Any())
                    {
                        for (int i = cli.Locations.Count() - 1; i >= 0; i--)
                        {
                            if (cli.Locations.ElementAt(i).id_film == monFilm.code_barre)
                            {
                                cli.Locations.Remove(cli.Locations.ElementAt(i));
                            }
                        }
                    }
                }
            }

            //On supprime le film dans l'objet ALL_FILMS
            FilmView.ALL_FILMS.Remove(monFilm);

            //On réinitialise la liste des films
            if (FilmView.ALL_FILMS.Any())
            {
                fv.InitFilms();
            }

            //On fait disparaître la modale
            this.Visibility = Visibility.Collapsed;

        }
    }
}

