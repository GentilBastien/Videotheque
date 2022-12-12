using MaVideotheque.Views;
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Linq;

namespace MaVideotheque.Modals
{
    public partial class ModalClientEdit : UserControl
    {
        public Client monClient = null;
        public ClientView cv = null;
        public Guid selectedClientId = Guid.Empty;
        public string Nom { get; set;}
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public ModalClientEdit(Client client)
        {
            InitializeComponent();
            this.DataContext = this;

            this.monClient = client;
            this.selectedClientId = client.id;
            this.Nom = client.nom;
            this.Prenom = client.prenom;
            this.Mail = client.mail;
            this.Tel = client.telephone;
            this.Adresse = client.adresse;

            
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
            String ConnectionString = MainWindow.CONNECTION_STRING;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(
                "UPDATE Clients SET " +
                "nom = @Nom, prenom = @Prenom, mail = @Mail, telephone = @Telephone, adresse = @Adresse WHERE id like '" + this.selectedClientId + "'", conn);

                command.Parameters.AddWithValue("@Nom", InputNom.Text);
                command.Parameters.AddWithValue("@Prenom", InputPrenom.Text);
                command.Parameters.AddWithValue("@Mail", InputMail.Text);
                command.Parameters.AddWithValue("@Telephone", InputTel.Text);
                command.Parameters.AddWithValue("@Adresse", InputAdresse.Text);

                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }

            cv.ReloadClientsAfterEdit(this.InputNom.Text, InputPrenom.Text, this.InputTel.Text, this.InputMail.Text, this.InputAdresse.Text);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
