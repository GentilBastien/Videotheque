using MaVideotheque.Components;
using MaVideotheque.Modals;
using System;
using System.Collections.Generic;
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
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;

namespace MaVideotheque.Views
{
    public partial class LocationView : UserControl
    {
        public static List<Location> ALL_LOCATIONS { get; set; }

        public Location selectedLocation = null;

        public LocationItem itemSelected = null;

        public Guid? selectedLocationId = null;
        public LocationView()
        {
            InitializeComponent();

            DatabaseEntities entities = new DatabaseEntities();
            var query3 = from location in entities.Locations
                         orderby location.rendu
                         ascending
                         select location;

            ALL_LOCATIONS = query3.ToList();

            InitLocations();
        }

        public void InitLocations()
        {
            this.selectedLocation = ALL_LOCATIONS.First();
            this.selectedLocationId = selectedLocation.id;
            this.MyStackLoc.Children.Clear();

            for(int i=0; i < ALL_LOCATIONS.Count();i++)
            {
                LocationItem myLocationItem = new LocationItem();
                myLocationItem.Titre = ALL_LOCATIONS.ElementAt(i).Film.titre;
                myLocationItem.NomClient = ALL_LOCATIONS.ElementAt(i).Client.prenom + "" + ALL_LOCATIONS.ElementAt(i).Client.nom;
                myLocationItem.NumLocation = ALL_LOCATIONS.ElementAt(i).id.ToString();
                myLocationItem.Prix = ALL_LOCATIONS.ElementAt(i).Film.prix.ToString() + "€";
                myLocationItem.LocStart = ALL_LOCATIONS.ElementAt(i).date_debut.ToShortDateString();
                myLocationItem.LocEnd = ALL_LOCATIONS.ElementAt(i).date_fin.ToShortDateString();
                myLocationItem.MouseLeftButtonDown += LocationItem_PreviewMouseLeftButtonDown;
                if (ALL_LOCATIONS.ElementAt(i).rendu)
                {
                    myLocationItem.Etat = new LocationState(0);
                }
                else
                {
                    if (ALL_LOCATIONS.ElementAt(i).date_fin < System.DateTime.Today)
                    {
                        myLocationItem.Etat = new LocationState(2);
                    }
                    else
                    {
                        myLocationItem.Etat = new LocationState(1);
                    }
                }


                    this.MyStackLoc.Children.Add(myLocationItem);
            }

            UpdateSelectedLocation();

        }

        public void UpdateSelectedLocation()
        {
            this.TopIdLoc.Content = selectedLocation.id.ToString();
            this.TopIdClient.Content = selectedLocation.id_client.ToString();
            this.TopTitreFilm.Content = selectedLocation.Film.titre.ToString();
            this.TopNomClient.Content = selectedLocation.Client.prenom + " " + selectedLocation.Client.prenom;
            this.TopCodeBarre.Content = selectedLocation.id_film.ToString();
            this.TopPrix.Content = selectedLocation.Film.prix + "€";
            this.TopDateDebut.Content = selectedLocation.date_debut.ToShortDateString();
            this.TopDateFin.Content = selectedLocation.date_fin.ToShortDateString();

            myState.Children.Clear();
            if (selectedLocation.rendu)
            {
                this.myState.Children.Add( new LocationState(0));
            }
            else
            {
                if (selectedLocation.date_fin < System.DateTime.Now)
                {
                    this.myState.Children.Add(new LocationState(2));
                }
                else
                {
                    this.myState.Children.Add(new LocationState(1));
                }
            }
            //this.TopRendu.Content = selectedLocation.rendu.ToString();


        }


        private void BtnCancelLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalLocationDelete modal = new ModalLocationDelete(this.selectedLocation);
            modal.SetLocationView(this);
            LocationMainContainer.Children.Add(modal);
        }

        private void BtnEditLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalLocationEdit modal = new ModalLocationEdit(this.selectedLocation);
            modal.SetLocationView(this);
            LocationMainContainer.Children.Add(modal);
        }

        private void BtnMajLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalLocationMaj modal = new ModalLocationMaj(selectedLocation);
            modal.SetLocationView(this);
            LocationMainContainer.Children.Add(modal);
        }

        private void LocationItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LocationItem item = e.Source as LocationItem;
            this.selectedLocationId = Guid.Parse(item.NumLocation);
            this.selectedLocation = (from location in ALL_LOCATIONS where location.id == this.selectedLocationId select location).First();
            this.itemSelected = item;
            UpdateSelectedLocation();
        }

        private void BtnActualiser_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InitLocations();
        }

        public void ReloadLocationAfterEdit(long CodeBarre, string DateDebut, string DateFin)
        {
            int index = ALL_LOCATIONS.IndexOf(this.selectedLocation);
            this.selectedLocation.id_film = CodeBarre;
            this.selectedLocation.date_debut = System.DateTime.Parse(DateDebut);
            this.selectedLocation.date_fin = System.DateTime.Parse(DateFin);

            ALL_LOCATIONS.RemoveAt(index);
            ALL_LOCATIONS.Insert(index, this.selectedLocation);
            InitLocations();

        }
    }
}
