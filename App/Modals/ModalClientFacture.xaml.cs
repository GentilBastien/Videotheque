using MaVideotheque.Components;
using MaVideotheque.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalClientFacture : UserControl
    {
        public string Titre { get; set; }
        public List<Location> myLocs {get; set;}

        public ClientView cv = null;
        public Client monClient { get; set; }
        public ModalClientFacture(Client client)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Titre = "Facture de " + client.nom + " " + client.prenom;

            //On récupère toutes les locations du client dans une List
            myLocs = (List<Location>)client.Locations.ToList();

            //on crée la partie visuelle : pour chaque location,
            //une checkbox et un ClientLocationItem associé.
            for(int i=0; i < client.Locations.Count; i++)
            {
                //On déclare nos éléments visuels
                CheckBox c = new CheckBox();
                ClientLocationItem t = new ClientLocationItem();

                //On les remplit
                t.FilmId = client.Locations.ElementAt(i).Film.code_barre.ToString();
                t.FilmName = client.Locations.ElementAt(i).Film.titre;
                t.LocationStart = client.Locations.ElementAt(i).date_debut.ToShortDateString();
                t.LocationEnd = client.Locations.ElementAt(i).date_fin.ToShortDateString();
                
                //On gère l'interaction visuelle (correspondance) entre les deux éléments
                t.Height = 30;
                c.Margin = new System.Windows.Thickness(0, 15, 0, 15);
                t.Margin = new System.Windows.Thickness(25, 15, 0, 15);
                c.Height = 30;
                t.Width = 750;

                //on ajoute l'état de la location
                if (client.Locations.ElementAt(i).rendu)
                {
                    t.Etat = new LocationState(0); //rendu
                    
                }
                else
                {
                    if(client.Locations.ElementAt(i).date_fin < System.DateTime.Today)
                    {
                        t.Etat = new LocationState(2); //en retard
                    }
                    else
                    {
                        t.Etat = new LocationState(1); //en prêt
                    }
                   
                }
               
                //on ajoute ces deux éléments conjointement dans leur élément
                this.myCheckBoxes.Children.Add(c);
                this.myClientLocationItems.Children.Add(t);
            }

            //this.myStack.Children.Add(myList);
        }


        public void SetClientView(object parent)
        {
            cv = (ClientView)parent;
        }
        private void ClicAilleurs(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        public void Afficher_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //Ici, on filtre les checkbox suivant si elles ont été cochées
            //Dans les faits, on supprime celles qui n'ont pas été cochées.
            for(int i = this.myLocs.Count-1; i>=0 ; i--)
            {
                CheckBox thisCheck = (CheckBox)this.myCheckBoxes.Children[i];
                if(thisCheck.IsChecked == false)
                {
                    myLocs.RemoveAt(i);
                }
            }

            //On initialise le prix des locations
            double prix_locations = 0.0;
            foreach(Location loc in myLocs)
            {
                //on fait une combinaison linéaire afin d'obtenir le montant total dû
                prix_locations += loc.date_fin.Subtract(loc.date_debut).Days*loc.Film.prix/7;
            }

            //On affiche le prix total dû par le client pour les locations sélectionnées
            this.mainStack.Children.Clear();
            Label facture = new Label();
            facture.Content = "Montant dû pour les locations sélectionnées : "+prix_locations.ToString()+"€";
            this.mainStack.Children.Add(facture);
            
        }

        private void Imprimer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.Visibility = Visibility.Collapsed;
        }

        private void Envoyer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.Visibility = Visibility.Collapsed;
        }
    }
}
