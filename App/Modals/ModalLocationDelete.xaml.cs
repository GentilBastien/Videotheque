using MaVideotheque.Views;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalLocationDelete : UserControl
    {
        public string Msg { get; set; }

        public LocationView lv = null;

        public Location location = null;
        public ModalLocationDelete(Location myLocation)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Msg = "Êtes-vous sûr de vouloir supprimer la location " + myLocation.id + " de la liste des locations ?";
            this.location = myLocation;
        }

        public void SetLocationView(object parent)
        {
            lv = (LocationView)parent;
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
            //en cliquant sur valider
            using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
            {
                var queryDelete = "delete from Locations where id like '" + this.location.id.ToString().ToUpper() + "'";

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryDelete;
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }

            //on récupère le film associé à la location
            Film myFilm = (Film)(from location in LocationView.ALL_LOCATIONS where location.id == this.location.id select location.Film).First();
            myFilm = (from film in FilmView.ALL_FILMS where film.code_barre == myFilm.code_barre select film).First();

            //si la location n'était pas rendue (cas d'une erreur du gérant par ex)
            if (!location.rendu)
            {
                //on décrémente le nombre d'exemplaires loués
                myFilm.exemplaires_loues--;

                using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                {
                    var queryDelete = "UPDATE Films SET exemplaires_loues=" + (this.location.Film.exemplaires_loues - 1) + " WHERE code_barre = " + this.location.Film.code_barre;

                    SqlCommand sqlCommand = conn.CreateCommand();
                    sqlCommand.CommandText = queryDelete;
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            

            //on supprime la location de notre objet film
            var queryloc = (from location in myFilm.Locations where location.id == this.location.id select location).First();
            myFilm.Locations.Remove(queryloc);

            //on supprime la location de nos locations statiques
            LocationView.ALL_LOCATIONS.Remove(location);

            //on supprime la location de la liste des locations du client concerné
            Client myClient = (from client in ClientView.ALL_CLIENTS where client.id == location.Client.id select client).First();
            myClient.Locations.Remove(location);

            //on réinitialise l'affichage
            this.lv.InitLocations();

            //on fait disparaître la modale
            this.Visibility = Visibility.Collapsed;

        }
    }
}
