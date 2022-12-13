using MaVideotheque.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Data.SqlClient;
using System;

namespace MaVideotheque.Modals
{
    public partial class ModalLocationEdit : UserControl
    {
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

            this.Titre = "Éditer la location n°" + maLocation.id;
            this.CodeBarre = maLocation.Film.code_barre;
            this.NomClient = maLocation.Client.prenom +" "+ maLocation.Client.nom;
            this.DateDebut = maLocation.date_debut.ToShortDateString();
            this.DateFin = maLocation.date_fin.ToShortDateString();
            this.maLocation = maLocation;
        }

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
            String ConnectionString = MainWindow.CONNECTION_STRING;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
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

            lv.ReloadLocationAfterEdit(this.CodeBarre, InputDateDebut.Text, InputDateFin.Text);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
