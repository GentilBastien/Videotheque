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
        //va contenir le client que l'on va modifier
        public Client monClient = null;
        //référence à la vue ayant déclanché la modale
        public ClientView cv = null;
        //Les informations sur le client
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

            //On intitialise les données de la modale
            //concernées par le data binding
            this.Nom = client.nom;
            this.Prenom = client.prenom;
            this.Mail = client.mail;
            this.Tel = client.telephone;
            this.Adresse = client.adresse;

            
        }

        //On lie la modale à la vue qui l'a générée
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

            using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(
                "UPDATE Clients SET " +
                "nom = @Nom, prenom = @Prenom, mail = @Mail, telephone = @Telephone, adresse = @Adresse WHERE id like '" + this.monClient.id + "'", conn);

                command.Parameters.AddWithValue("@Nom", InputNom.Text);
                command.Parameters.AddWithValue("@Prenom", InputPrenom.Text);
                command.Parameters.AddWithValue("@Mail", InputMail.Text);
                command.Parameters.AddWithValue("@Telephone", InputTel.Text);
                command.Parameters.AddWithValue("@Adresse", InputAdresse.Text);

                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }

            //On change les informations du client modifié
            monClient.nom = InputNom.Text;
            monClient.prenom = InputPrenom.Text;
            monClient.telephone = InputTel.Text;
            monClient.adresse = InputAdresse.Text;
            monClient.mail = InputMail.Text;

            //on réactualise la vue ClientView
            cv.InitClients();
            cv.UpdateSelectedClient(monClient.id);

            //on fait disparaître la modale
            this.Visibility = Visibility.Collapsed;

        }
    }
}
