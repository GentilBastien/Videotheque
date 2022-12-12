using MaVideotheque.Views;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;

namespace MaVideotheque.Modals
{
    
    public partial class ModalLocationAdd : UserControl
    {
        public string Msg { get; set; }

        public ClientView cv = null;

        public Client SelectedClient { get; set; }


        public long? filmId = null;
        public ModalLocationAdd(Client monClient)
        {
            InitializeComponent();
            this.DataContext = this;

            this.SelectedClient = monClient;

            this.Msg = "Location de film pour " + monClient.prenom + " " + monClient.nom;
        }

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
            var query = from film in FilmView.ALL_FILMS where film.code_barre == Int64.Parse(this.InputCodeBarre.Text) select film;

            if (query.Any())
            {
                Location MyNewLoc = new Location();
                MyNewLoc.id_client = SelectedClient.id;
                MyNewLoc.id_film = Int64.Parse(this.InputCodeBarre.Text);
                MyNewLoc.Film = query.First();
                MyNewLoc.id = System.Guid.NewGuid();
                MyNewLoc.rendu = false;
                MyNewLoc.date_debut = System.DateTime.Parse(this.InputDateDebut.Text);
                MyNewLoc.date_fin = System.DateTime.Parse(this.InputDateFin.Text);
                MyNewLoc.Client = SelectedClient;

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

                LocationView.ALL_LOCATIONS.Add(MyNewLoc);
                SelectedClient.Locations.Add(MyNewLoc);
                cv.InitClients();

            }

            this.Visibility = Visibility.Collapsed;
        }
    }
}
