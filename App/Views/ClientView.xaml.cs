using MaVideotheque.Components;
using MaVideotheque.DatabaseDataSetTableAdapters;
using MaVideotheque.Modals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaVideotheque.Views
{
    public partial class ClientView : UserControl
    {
        public Guid selectedClientId;
        public Client selectedClient;
        public ClientItem itemSelected = null;
        public static List<Client> ALL_CLIENTS { get; set; }


        public ClientView()
        {
            InitializeComponent();
            this.DataContext = this;

            var entities = new DatabaseEntities();


            var query2 = from client in entities.Clients
                         orderby client.Locations.Count()
                         descending
                         select client;

            ALL_CLIENTS = query2.ToList();

            InitClients() ;
        }

        public void InitClients()
        {
            this.selectedClient = ALL_CLIENTS.First();
            this.selectedClientId = this.selectedClient.id;
            

            ClientItems.Children.Clear();

            for(int i =0; i < ALL_CLIENTS.Count; i++)
            {
                ClientItem LigneClient = new ClientItem();
                LigneClient.ClientID = ALL_CLIENTS.ElementAt(i).id.ToString();
                LigneClient.ClientNom = ALL_CLIENTS.ElementAt(i).nom;
                LigneClient.ClientPrenom = ALL_CLIENTS.ElementAt(i).prenom;
                LigneClient.ClientMail = ALL_CLIENTS.ElementAt(i).mail;
                LigneClient.ClientTel = ALL_CLIENTS.ElementAt(i).telephone;
                LigneClient.ClientAdresse = ALL_CLIENTS.ElementAt(i).adresse;
                var query = from location in ALL_CLIENTS.ElementAt(i).Locations where !location.rendu select location;
                LigneClient.MouseLeftButtonDown += ClientItem_PreviewMouseLeftButtonDown;
                LigneClient.ClientNbLocations = query.ToList().Count().ToString();
                ClientItems.Children.Add(LigneClient);
            }
            UpdateSelectedClient();

        }

        public void UpdateSelectedClient()
        {
            this.TopName.Content = selectedClient.prenom +" "+ selectedClient.nom;
            this.TopId.Content = selectedClient.id;
            this.TopNom.Content = selectedClient.nom;
            this.TopPrenom.Content = selectedClient.prenom;
            this.TopMail.Content = selectedClient.mail;
            this.TopTel.Content = selectedClient.telephone;
            this.TopAdresse.Content = selectedClient.adresse;
            this.TopDateNaissance.Content = selectedClient.date_naissance.ToShortDateString();

            this.LocationsStack.Children.Clear();
            for(int i=0; i < selectedClient.Locations.Count(); i++)
            {
                ClientLocationItem itemLoc = new ClientLocationItem();
                itemLoc.FilmId = selectedClient.Locations.ElementAt(i).Film.code_barre.ToString();
                itemLoc.FilmName = selectedClient.Locations.ElementAt(i).Film.titre.ToString();
                if (selectedClient.Locations.ElementAt(i).rendu)
                {
                    itemLoc.Etat = "Rendu";

                }
                else
                {
                    itemLoc.Etat = "Non rendu";

                }
                itemLoc.LocationStart = selectedClient.Locations.ElementAt(i).date_debut.ToShortDateString();
                itemLoc.LocationEnd = selectedClient.Locations.ElementAt(i).date_fin.ToShortDateString();
                LocationsStack.Children.Add(itemLoc);
            }

        }
        public void ReloadClientsAfterDelete()
        {
            Client deletedClient = this.selectedClient;
            ALL_CLIENTS.Remove(deletedClient);
            this.selectedClient = ALL_CLIENTS.First();
            this.selectedClientId = this.selectedClient.id;
            InitClients();
        }

        public void ReloadClientsAfterAdd(Client newClient)
        {
            ALL_CLIENTS.Add(newClient);
            this.selectedClient = ALL_CLIENTS.Last();
            this.selectedClientId = newClient.id;
            InitClients();
        }

        public void ReloadClientsAfterEdit(string Nom, string Prenom, string Tel, string Mail, string Adresse)
        {
            Client myChangedClient = this.selectedClient;
            int indexClient = ALL_CLIENTS.IndexOf(myChangedClient);
            ALL_CLIENTS.Remove(myChangedClient);
            myChangedClient.nom = Nom;
            myChangedClient.prenom = Prenom;
            myChangedClient.telephone = Tel;
            myChangedClient.mail = Mail;
            myChangedClient.adresse = Adresse;
            ALL_CLIENTS.Insert(indexClient,myChangedClient);
            InitClients();
            
        }

        private void ClientItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClientItem item = e.Source as ClientItem;
            this.selectedClientId = Guid.Parse(item.ClientID);
            this.selectedClient = (from client in ALL_CLIENTS where client.id == this.selectedClientId select client).First();
            this.itemSelected = item;
            UpdateSelectedClient();

        }

        private void BtnDeleteClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientDelete modal = new ModalClientDelete(this.selectedClient);
            modal.SetClientView(this);
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnEditClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientEdit modal = new ModalClientEdit(this.selectedClient);
            modal.SetClientView(this);
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnFactureClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientFacture modal = new ModalClientFacture("ROISSY", "Pierre");
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnLouerFilm_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalLocationAdd modal = new ModalLocationAdd(selectedClient);
            modal.SetClientView(this);
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnAddClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientAdd modal = new ModalClientAdd();
            modal.SetClientView(this);
            ClientMainContainer.Children.Add(modal);
        }

        
    }
}
