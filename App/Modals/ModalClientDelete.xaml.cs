using MaVideotheque.Views;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

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

            //on initialise les attributs : le client qui sera supprimé
            this.clientSelected = client;
            //le message de confirmation de suppression data-bindé
            this.Msg = "Êtes-vous sûr de vouloir supprimer " + client.prenom + " " + client.nom + " de la liste des clients ?";
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
            SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING);
            string[] querysDelete = {"delete from Locations where id_client like '"+this.clientSelected.id.ToString().ToUpper()+"'",
            "delete from Clients where id like '"+this.clientSelected.id.ToString().ToUpper()+"'"};

            for (int i = 0; i < querysDelete.Length; i++)
            {
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = querysDelete[i];
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }


            //On supprime toutes les locations associées à ce client
            ClientView.ALL_CLIENTS.Remove(clientSelected);
            var queryLocs = from location in LocationView.ALL_LOCATIONS where location.Client.id == clientSelected.id select location;
            for(int i = 0; i< queryLocs.Count(); i++)
            {
                LocationView.ALL_LOCATIONS.Remove(queryLocs.ToList().ElementAt(i));
            }

            //On supprime toutes les locations associées à ce client de nos objets Film
            foreach(Film f in FilmView.ALL_FILMS)
            {
                for(int i = f.Locations.Count - 1; i <= 0; i--)
                {
                    if(f.Locations.ElementAt(i).Client.id == clientSelected.id)
                    {
                        f.Locations.Remove(f.Locations.ElementAt(i));
                    }
                }
            }

            //On recharge la vue ClientView
            if (ClientView.ALL_CLIENTS.Any())
            {
                cv.InitClients();
            }

            //On fait disparaître la modale
            this.Visibility = Visibility.Collapsed;
        }
    }
}
