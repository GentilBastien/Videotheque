using MaVideotheque.Views;
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Linq;

namespace MaVideotheque.Modals
{
    public partial class ModalClientDelete : UserControl
    {
        public string Msg { get; set; }

        public ClientView cv = null;

        public Client clientSelected = null;
        public ModalClientDelete(Client client)
        {
            InitializeComponent();
            this.DataContext = this;
            this.clientSelected = client;
            this.Msg = "Êtes-vous sûr de vouloir supprimer " + client.prenom + " " + client.prenom + " de la liste des clients ?";
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

            DataContext db = new DataContext(ConnectionString);

            SqlConnection conn = new SqlConnection(ConnectionString);
            string[] querysDelete = {"delete from Locations where id_client like '"+this.clientSelected.id.ToString().ToUpper()+"'",
            "delete from Clients where id like '"+this.clientSelected.id.ToString().ToUpper()+"'"};

            for (int i = 0; i < querysDelete.Length; i++)
            {
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = querysDelete[i];
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                db.SubmitChanges();
            }

            db.Connection.Close();
            cv.ReloadClientsAfterDelete();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
