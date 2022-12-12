using MaVideotheque.Components;
using MaVideotheque.Views;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalClientAdd : UserControl
    {
        public ClientView cv = null;
        public ModalClientAdd()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void SetClientView(object parent)
        {
            this.cv = parent as ClientView; // on stocke le parent actuel
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
            Guid myGuid = System.Guid.NewGuid();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(
                "INSERT INTO Clients " +
                "VALUES (@Id, @Nom, @Prenom, @Mail, @Telephone, @Adresse, @DateNaissance)", conn);

                
                command.Parameters.AddWithValue("@Id", myGuid);
                command.Parameters.AddWithValue("@Nom", InputNom.Text);
                command.Parameters.AddWithValue("@Prenom", InputPrenom.Text);
                command.Parameters.AddWithValue("@Mail", InputMail.Text);
                command.Parameters.AddWithValue("@Telephone", InputTel.Text);
                command.Parameters.AddWithValue("@Adresse", InputAdresse.Text);
                command.Parameters.AddWithValue("@DateNaissance", InputDateNaissance.Text);

                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }

            Client myNewClient = new Client();
            myNewClient.id = myGuid;
            myNewClient.nom = InputNom.Text;
            myNewClient.prenom = InputPrenom.Text;
            myNewClient.mail = InputMail.Text;
            myNewClient.telephone = InputTel.Text;
            myNewClient.adresse = InputAdresse.Text;
            myNewClient.date_naissance = DateTime.Parse(InputDateNaissance.Text);
            cv.ReloadClientsAfterAdd(myNewClient);
            
            this.Visibility = Visibility.Collapsed;
        }
    }
}
