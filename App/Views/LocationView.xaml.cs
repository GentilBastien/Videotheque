using MaVideotheque.Components;
using MaVideotheque.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;


namespace MaVideotheque.Views
{
    public partial class LocationView : UserControl
    {
        //Nos entités
        public static List<Location> ALL_LOCATIONS { get; set; }

        //Notre location sélectionnée
        public Location SelectedLocation = null;

        
        public LocationView()
        {
            InitializeComponent();

            DatabaseEntities entities = new DatabaseEntities();
            ALL_LOCATIONS = (from location in entities.Locations
                         orderby location.rendu
                         ascending
                         select location).ToList();

            if (ALL_LOCATIONS.Any())
            {
                InitLocations();
            }

        }

        public void InitLocations()
        {

            //On initialise SelectedLocation
            this.SelectedLocation = ALL_LOCATIONS.First();
            
            //On clear le stack des locations
            this.MyStackLoc.Children.Clear();

            //On le re-remplit avec les bonnes données
            for(int i=0; i < ALL_LOCATIONS.Count();i++)
            {
                //Instanciation d'un nouvel item
                LocationItem myLocationItem = new LocationItem();

                //Remplissage
                myLocationItem.Titre = ALL_LOCATIONS.ElementAt(i).Film.titre;
                myLocationItem.NomClient = ALL_LOCATIONS.ElementAt(i).Client.prenom + "" + ALL_LOCATIONS.ElementAt(i).Client.nom;
                myLocationItem.NumLocation = ALL_LOCATIONS.ElementAt(i).id.ToString();
                myLocationItem.Prix = ALL_LOCATIONS.ElementAt(i).Film.prix.ToString() + "€";
                myLocationItem.LocStart = ALL_LOCATIONS.ElementAt(i).date_debut.ToShortDateString();
                myLocationItem.LocEnd = ALL_LOCATIONS.ElementAt(i).date_fin.ToShortDateString();

                
                if (ALL_LOCATIONS.ElementAt(i).rendu)
                {
                    myLocationItem.Etat = new LocationState(0); //rendu
                }
                else
                {
                    if (ALL_LOCATIONS.ElementAt(i).date_fin < System.DateTime.Today)
                    {
                        myLocationItem.Etat = new LocationState(2); //En retard
                    }
                    else
                    {
                        myLocationItem.Etat = new LocationState(1); //Location en cours
                    }
                }

                //Ajout de l'évènement clic
                myLocationItem.MouseLeftButtonDown += LocationItem_PreviewMouseLeftButtonDown;

                //On ajoute l'item au stack
                this.MyStackLoc.Children.Add(myLocationItem);
            }

            UpdateSelectedLocation(SelectedLocation.id);
        }

        public void UpdateSelectedLocation(Guid id)
        {
            //On recharge Selected Location dans le cas d'un passage ultérieur à l'init
            this.SelectedLocation = (from location in ALL_LOCATIONS where location.id == id select location).First();

            //On remplit les informations de la partie haute
            this.TopIdLoc.Content = SelectedLocation.id.ToString();
            this.TopIdClient.Content = SelectedLocation.id_client.ToString();
            this.TopTitreFilm.Content = SelectedLocation.Film.titre.ToString();
            this.TopNomClient.Content = SelectedLocation.Client.prenom + " " + SelectedLocation.Client.nom;
            this.TopCodeBarre.Content = SelectedLocation.id_film.ToString();
            this.TopPrix.Content = SelectedLocation.Film.prix + "€";
            this.TopDateDebut.Content = SelectedLocation.date_debut.ToShortDateString();
            this.TopDateFin.Content = SelectedLocation.date_fin.ToShortDateString();

            //On initialise le location state

            //on clear l'ancien, au cas où y en avait un
            myState.Children.Clear();

            if (SelectedLocation.rendu)
            {
                this.myState.Children.Add( new LocationState(0)); //rendu
            }
            else
            {
                if (SelectedLocation.date_fin < System.DateTime.Now)
                {
                    this.myState.Children.Add(new LocationState(2)); //retard
                }
                else
                {
                    this.myState.Children.Add(new LocationState(1)); //en cours
                }
            }

        }

        //Modale d'annulation de location
        private void BtnCancelLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_LOCATIONS.Any())
            {
                ModalLocationDelete modal = new ModalLocationDelete(this.SelectedLocation);
                modal.SetLocationView(this);
                LocationMainContainer.Children.Add(modal);
            }
            
        }

        //Modale d'édition d'une location
        private void BtnEditLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_LOCATIONS.Any())
            {
                ModalLocationEdit modal = new ModalLocationEdit(this.SelectedLocation);
                modal.SetLocationView(this);
                LocationMainContainer.Children.Add(modal);
            }
        }

        //Modale de mise à jour d'une location
        private void BtnMajLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_LOCATIONS.Any())
            {
                ModalLocationMaj modal = new ModalLocationMaj(SelectedLocation);
                modal.SetLocationView(this);
                LocationMainContainer.Children.Add(modal);
            }
            
        }

        //Action de clic sur un LocationItem
        private void LocationItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LocationItem item = e.Source as LocationItem;
            UpdateSelectedLocation(Guid.Parse(item.NumLocation));
        }

        private void BtnActualiser_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_LOCATIONS.Any())
            {
                InitLocations();
            }
            
        }

        //inutile ?
        public void ReloadLocationAfterEdit(long CodeBarre, string DateDebut, string DateFin)
        {
            int index = ALL_LOCATIONS.IndexOf(this.SelectedLocation);
            this.SelectedLocation.id_film = CodeBarre;
            this.SelectedLocation.date_debut = System.DateTime.Parse(DateDebut);
            this.SelectedLocation.date_fin = System.DateTime.Parse(DateFin);

            ALL_LOCATIONS.RemoveAt(index);
            ALL_LOCATIONS.Insert(index, this.SelectedLocation);
            InitLocations();

        }
    }
}
