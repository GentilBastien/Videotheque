using MaVideotheque.Components;
using MaVideotheque.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Views
{
    public partial class ClientView : UserControl
    {
        //Correspond au client affiché en haut de vue.
        //De base ce sera le premier client de la liste triée
        //par nb total de locations, sinon le dernier client cliqué 

        public Client SelectedClient;

        //Notre attribut statique contenant tous les clients
        public static List<Client> ALL_CLIENTS { get; set; }


        public ClientView()
        {
            InitializeComponent();
            this.DataContext = this;

            //On génère nos clients d'après les entités
            var entities = new DatabaseEntities();
            ALL_CLIENTS = (from client in entities.Clients
                         orderby client.Locations.Count()
                         descending
                         select client).ToList();

            //On initialise notre tableau du bas
            if (ALL_CLIENTS.Any())
            {
                InitClients();
            }
            
        }

        public void InitClients()
        {

            //On affecte une valeur à notre attribut SelectedClient
            this.SelectedClient = ALL_CLIENTS.First();
            
            //On clear toutes les entrées du tableau
            ClientItems.Children.Clear();

            //On re-remplit le tableau
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

            //On update l'affichage du haut
            UpdateSelectedClient(this.SelectedClient.id);

        }

        public void UpdateSelectedClient(Guid id)
        {
            //Vu que l'on va repasser ici autrement qu'à l'init,
            //On recharge SelectedClient
            this.SelectedClient = (from client in ALL_CLIENTS where client.id == id select client).First();

            //On remplit ainsi la partie haute de la vue
            this.TopName.Content = SelectedClient.prenom + " " + SelectedClient.nom;
            this.TopId.Content = SelectedClient.id;
            this.TopNom.Content = SelectedClient.nom;
            this.TopPrenom.Content = SelectedClient.prenom;
            this.TopMail.Content = SelectedClient.mail;
            this.TopTel.Content = SelectedClient.telephone;
            this.TopAdresse.Content = SelectedClient.adresse;
            this.TopDateNaissance.Content = SelectedClient.date_naissance.ToShortDateString();

            //On clear l'affichage des locations du client (ou des précédents)
            this.LocationsStack.Children.Clear();

            //On re-remplit avec les informations adaptées
            for(int i=0; i < SelectedClient.Locations.Count(); i++)
            {
                //On instancie un nouveau ClientLocationItem
                ClientLocationItem itemLoc = new ClientLocationItem();

                //On le remplit
                itemLoc.FilmId = SelectedClient.Locations.ElementAt(i).Film.code_barre.ToString();
                itemLoc.FilmName = SelectedClient.Locations.ElementAt(i).Film.titre.ToString();
                if (SelectedClient.Locations.ElementAt(i).rendu)
                {
                    itemLoc.Etat = new LocationState(0);

                }
                else
                {
                    itemLoc.Etat = new LocationState(2);

                }
                itemLoc.LocationStart = SelectedClient.Locations.ElementAt(i).date_debut.ToShortDateString();
                itemLoc.LocationEnd = SelectedClient.Locations.ElementAt(i).date_fin.ToShortDateString();

                //On l'ajoute au stack
                LocationsStack.Children.Add(itemLoc);
            }

        }

        //Lorsque l'on clique sur un élément du tableau de bas de vue
        private void ClientItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClientItem item = e.Source as ClientItem;
            UpdateSelectedClient(Guid.Parse(item.ClientID));

        }

        //La modale de supression du client
        private void BtnDeleteClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ALL_CLIENTS.Any())
            {
                ModalClientDelete modal = new ModalClientDelete(this.SelectedClient);
                modal.SetClientView(this);
                ClientMainContainer.Children.Add(modal);
            }
        }

        //La modale d'édition du client
        private void BtnEditClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ALL_CLIENTS.Any())
            {
                ModalClientEdit modal = new ModalClientEdit(this.SelectedClient);
                modal.SetClientView(this);
                ClientMainContainer.Children.Add(modal);
            }
        }

        //La modale de calcul de la facture du client
        private void BtnFactureClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ALL_CLIENTS.Any())
            {
                ModalClientFacture modal = new ModalClientFacture(SelectedClient);
                modal.SetClientView(this);
                ClientMainContainer.Children.Add(modal);
            }
        }

        //La modale permettant de louer un film à un client
        private void BtnLouerFilm_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ALL_CLIENTS.Any())
            {
                ModalLocationAdd modal = new ModalLocationAdd(SelectedClient);
                modal.SetClientView(this);
                ClientMainContainer.Children.Add(modal);
            }
        }

        //La modale permettant d'ajouter un client
        private void BtnAddClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientAdd modal = new ModalClientAdd();
            modal.SetClientView(this);
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnRefresh_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_CLIENTS.Any())
            {
                InitClients();
            }
        }
    }
}
