using MaVideotheque.Components;
using MaVideotheque.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalClientFacture : UserControl
    {
        public string Titre { get; set; }
        public List<Location> myLocs = null;
        public ClientView cv = null;
        public Client monClient { get; set; }
        public ModalClientFacture(Client client)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Titre = "Facture de " + client.nom + " " + client.prenom;

            myLocs = (List<Location>)client.Locations.ToList();

            for(int i=0; i < client.Locations.Count; i++)
            {
                CheckBox c = new CheckBox();
                ClientLocationItem t = new ClientLocationItem();
                t.FilmId = client.Locations.ElementAt(i).Film.code_barre.ToString();
                t.FilmName = client.Locations.ElementAt(i).Film.titre;
                t.LocationStart = client.Locations.ElementAt(i).date_debut.ToShortDateString();
                t.LocationEnd = client.Locations.ElementAt(i).date_fin.ToShortDateString();
                t.Height = 30;
                c.Margin = new System.Windows.Thickness(0, 15, 0, 15);
                t.Margin = new System.Windows.Thickness(25, 15, 0, 15);
                c.Height = 30;
                t.Width = 750;

                if (client.Locations.ElementAt(i).rendu)
                {
                    t.Etat = new LocationState(0);
                    
                }
                else
                {
                    if(client.Locations.ElementAt(i).date_fin < System.DateTime.Today)
                    {
                        t.Etat = new LocationState(2);
                    }
                    else
                    {
                        t.Etat = new LocationState(1);
                    }
                   
                }
               
                this.myCheckBoxes.Children.Add(c);
                this.myClientLocationItems.Children.Add(t);
            }

            //this.myStack.Children.Add(myList);
        }

        public void SetTitre(string titre)
        {
            this.Titre = titre;
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
            this.Titre = "siu";

            for(int i = this.myLocs.Count-1; i>=0 ; i--)
            {
                CheckBox thisCheck = (CheckBox)this.myCheckBoxes.Children[i];
                if(thisCheck.IsChecked == false)
                {
                    myLocs.RemoveAt(i);
                }
            }

            double prix_location = 0.0;
            foreach(Location loc in myLocs)
            {
                prix_location += loc.date_fin.Subtract(loc.date_debut).Days*loc.Film.prix/7;
            }

            this.myClientLocationItems.Children.Clear();
            Label siu = new Label();
            siu.Content = "Prix : "+prix_location.ToString();
            this.myClientLocationItems.Children.Add(siu);
            //ModalClientFacture modal = new ModalClientFacture(this.monClient);
            //this.cv.ClientMainContainer.Children.Add(modal);
            //this.Visibility = Visibility.Hidden;
        }

        private void Imprimer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Envoyer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
