using MaVideotheque.Components;
using MaVideotheque.Views;
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Linq;

namespace MaVideotheque.Modals
{
    public partial class ModalLocationMaj : UserControl
    {
        //Le texte dans la modale (en data binding)
        public string Titre { get; set; }

        public Location maLocation { get; set; }
        public bool rendu { get; set; }

        public LocationView lv = null;
        public ModalLocationMaj(Location maLocation)
        {
            InitializeComponent();
            this.DataContext = this;
            //on initialise les attributs
            this.maLocation = maLocation;
            this.Titre = "Mettre à jour la location n°" + maLocation.id.ToString();
            //booleen en data binding
            this.rendu = maLocation.rendu;

        }

        public void SetLocationView(object parent)
        {
            lv = (LocationView)parent;
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
            //on récupère le client associé à la location
            Client c = (from client in ClientView.ALL_CLIENTS where client.id == maLocation.Client.id select client).First();
            //on supprime la location obsolète dans ce client
            c.Locations.Remove(maLocation);

            //On fait pareil pour le film concerné
            Film f = (from film in FilmView.ALL_FILMS where film.code_barre == maLocation.Film.code_barre select film).First();
            f.Locations.Remove(maLocation);

            //Pour la bdd, on doit passer par des valeurs binaires
            int IntValue;
            if ((bool)this.myCheckbox.IsChecked)
            {
                IntValue = 1;
                maLocation.rendu = true;
            }
            else
            {
                IntValue = 0;
                maLocation.rendu = false;
            }

            //on ajoute la bonne location
            c.Locations.Add(maLocation);
            f.Locations.Add(maLocation);

            using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("UPDATE Locations SET rendu =" 
                    + IntValue + " WHERE id like '"+maLocation.id+"'", conn);
                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }


            //On modifie enfin l'objet ALL_LOCATIONS :
            Location loc = (from location in LocationView.ALL_LOCATIONS where location.id == maLocation.id select location).First();
            loc.rendu = maLocation.rendu;

            //on fait disparaître la modale
            this.Visibility = Visibility.Collapsed;
        }
    }
}
