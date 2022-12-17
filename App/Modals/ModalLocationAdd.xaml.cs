using MaVideotheque.Views;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    
    public partial class ModalLocationAdd : UserControl
    {
        public string Msg { get; set; }

        public ClientView cv = null;

        public Client SelectedClient { get; set; }


        public ModalLocationAdd(Client monClient)
        {
            InitializeComponent();
            this.DataContext = this;

            //On set nos attributs
            this.SelectedClient = monClient;
            this.Msg = "Location de film pour " + monClient.prenom + " " + monClient.nom;
        }
        //on lie la modale à la ClientView
        public void SetClientView(object parent)
        {
            this.cv = parent as ClientView;
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
            //on récupère le film concerné
            var queryFilm = from film in FilmView.ALL_FILMS where film.code_barre == Int64.Parse(this.InputCodeBarre.Text) select film;

            if (queryFilm.Any())
            {
                Location MyNewLoc = new Location();
                MyNewLoc.id_client = SelectedClient.id;
                MyNewLoc.id_film = Int64.Parse(this.InputCodeBarre.Text);
                MyNewLoc.Film = queryFilm.First();
                MyNewLoc.id = System.Guid.NewGuid();
                MyNewLoc.rendu = false;
                MyNewLoc.date_debut = System.DateTime.Parse(this.InputDateDebut.Text);
                MyNewLoc.date_fin = System.DateTime.Parse(this.InputDateFin.Text);
                MyNewLoc.Client = SelectedClient;

                //on crée une nouvelle location dans la BDD
                using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand(
                    "INSERT INTO Locations " +
                    "VALUES (@Id, @IdClient, @IdFilm, @Rendu, @DateDebut, @DateFin)", conn);


                    command.Parameters.AddWithValue("@Id", MyNewLoc.id);
                    command.Parameters.AddWithValue("@IdFilm", MyNewLoc.Film.code_barre);
                    command.Parameters.AddWithValue("@IdCLient", MyNewLoc.id_client);
                    command.Parameters.AddWithValue("@Rendu", MyNewLoc.rendu);
                    command.Parameters.AddWithValue("@DateDebut", MyNewLoc.date_debut);
                    command.Parameters.AddWithValue("@DateFin", MyNewLoc.date_fin);

                    adapter.InsertCommand = command;
                    conn.Open();
                    adapter.InsertCommand.ExecuteNonQuery();
                }

                //on incrémente le nombre d'exemplaires loués du film
                using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand(
                    "UPDATE Films SET exemplaires_loues="+ (queryFilm.First().exemplaires_loues + 1) + "WHERE code_barre like '"+Int64.Parse(this.InputCodeBarre.Text)+"'", conn);

                    adapter.InsertCommand = command;
                    conn.Open();
                    adapter.InsertCommand.ExecuteNonQuery();
                }

                //on ajoute l'objet location crée dans la liste des locations
                LocationView.ALL_LOCATIONS.Add(MyNewLoc);

                //on ajoute la location dans la liste des locations du client sélectionné
                SelectedClient.Locations.Add(MyNewLoc);

                //on ajoute la location dans la liste des locations du film concerné
                queryFilm.First().Locations.Add(MyNewLoc);

                //on incrémente les exemplaires loués
                queryFilm.First().exemplaires_loues++;

                //on réinitialise l'affichage de la vue ClientView
                cv.InitClients();
                cv.UpdateSelectedClient(MyNewLoc.id_client);

            }
            //on masque la modale
            this.Visibility = Visibility.Collapsed;
        }
    }
}
