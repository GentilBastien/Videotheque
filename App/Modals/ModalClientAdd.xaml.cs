using MaVideotheque.Views;
using System;
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
            //On crée un  nouveau client directement si tous les champs sont remplis
            if (InputNom.Text != "" && InputPrenom.Text != "" && InputMail.Text != "" & InputTel.Text != "" && InputAdresse.Text != "" && InputDateNaissance.Text != "")
            {


                Guid myGuid = System.Guid.NewGuid();

                using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
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

                //on crée maintenant l'objet client, et on l'insère dans
                //notre objet ALL_CLIENTS
                Client myNewClient = new Client();
                myNewClient.id = myGuid;
                myNewClient.nom = InputNom.Text;
                myNewClient.prenom = InputPrenom.Text;
                myNewClient.mail = InputMail.Text;
                myNewClient.telephone = InputTel.Text;
                myNewClient.adresse = InputAdresse.Text;
                myNewClient.date_naissance = DateTime.Parse(InputDateNaissance.Text);

                ClientView.ALL_CLIENTS.Add(myNewClient);
                cv.InitClients();
                cv.UpdateSelectedClient(myNewClient.id);

                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}
