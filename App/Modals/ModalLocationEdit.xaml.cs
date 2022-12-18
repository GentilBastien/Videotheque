using MaVideotheque.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Data.SqlClient;

namespace MaVideotheque.Modals
{
    public partial class ModalLocationEdit : UserControl
    {
        //On set le databinding
        public string Titre { get; set; }
        public long CodeBarre { get; set; }
        public string NomClient { get; set; }
        public string DateDebut { get; set; }
        public string DateFin { get; set; }

        public LocationView lv = null;

        public Location maLocation = null; 
        public ModalLocationEdit(Location maLocation)
        {
            InitializeComponent();
            this.DataContext = this;

            //on set les attributs
            this.Titre = "Éditer la location n°" + maLocation.id;
            this.CodeBarre = maLocation.Film.code_barre;
            //affichage pour ne pas commettre d'erreurs
            this.NomClient = maLocation.Client.prenom +" "+ maLocation.Client.nom;
            this.DateDebut = maLocation.date_debut.ToShortDateString();
            this.DateFin = maLocation.date_fin.ToShortDateString();
            this.maLocation = maLocation;
        }
        //on lie la modale à la LocationView
        public void SetLocationView(object parent)
        {
            this.lv = parent as LocationView;
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

            //si l'on valide les modifications 

            using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(
                "UPDATE Locations SET " +
                "id_film = @IdFilm, date_debut = @DateDebut, date_fin = @DateFin WHERE id like '" + this.maLocation.id + "'", conn);

                command.Parameters.AddWithValue("@IdFilm", this.CodeBarre);
                command.Parameters.AddWithValue("@DateDebut", System.DateTime.Parse(InputDateDebut.Text));
                command.Parameters.AddWithValue("@DateFin", System.DateTime.Parse(InputDateFin.Text));


                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }

            //on modifie l'objet location
            maLocation.id_film = this.CodeBarre;
            maLocation.date_debut = System.DateTime.Parse(this.DateDebut);
            maLocation.date_fin = System.DateTime.Parse(this.DateFin);

            //on modifie le filmm concerné dans FilmView.ALL_FILMS
            Film monFilm = (from film in FilmView.ALL_FILMS where film.code_barre == this.CodeBarre select film).First();
            Location maFilmLoc = (from location in monFilm.Locations where location.id == maLocation.id select location).First();
            maFilmLoc.date_debut = System.DateTime.Parse(this.DateDebut);
            maFilmLoc.date_fin = System.DateTime.Parse(this.DateFin);

            //on modifie le client concerné dans ClientView.ALL_CLIENTS
            Client monClient = (from client in ClientView.ALL_CLIENTS where client.id == maLocation.id_client select client).First();
            Location maClientLoc = (from location in monClient.Locations where location.id == maLocation.id select location).First();
            maClientLoc.date_debut = System.DateTime.Parse(this.DateDebut);
            maClientLoc.date_fin = System.DateTime.Parse(this.DateFin);

            //On réinitialisa l'affichage
            lv.InitLocations();
            lv.UpdateSelectedLocation(maLocation.id);

            //on masque la modale
            this.Visibility = Visibility.Collapsed;
        }

    }
}
