using MaVideotheque.Components;
using MaVideotheque.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MaVideotheque.Views
{
    public partial class FilmView : UserControl
    {
        //Correspond au film affiché en haut de vue.
        //De base ce sera le premier film de la liste triée, sinon le dernier film cliqué 
        public Film SelectedFilm { get; set; }

        //Cet élément statique contient toutes les entités du type film
        public static List<Film> ALL_FILMS { get; set; }



        public FilmView()
        {
           
            InitializeComponent();
            this.DataContext = this;

            //Ici, on charge nos entités dans notre élément statique ALL_FILMS à l'aide
            //d'une requête LinQ
            var entities = new DatabaseEntities();

            ALL_FILMS = (from film in entities.Films
                         orderby film.Locations.Count() descending
                         select film).ToList();

            //On initialise ensuite les composants visuels et SelectedFilm
            if (ALL_FILMS.Any())
            {
                InitFilms();
            }
            else
            {
                this.SelectedFilm = null;
            }
            
        }

        //Cette méthode statique nous permet de convertir les minutes au format heures:minutes
        //Utile pour afficher la durée du film de façon lisible dans notre vue
        public static String convert(int? mins)
        {
            int? hours = (mins - mins % 60) / 60;
            return "" + hours + "h" + (mins - hours * 60);
        }


        public void InitFilms()
        {
            //On commence par initialiser SelectedFilm
            this.SelectedFilm = ALL_FILMS.First();
            
            //La méthode InitFilms sera souvent appelée (à chaque modification de BDD), donc
            //on réinitialise tableau de films à chaque passage pour rendre l'affichage dynamique 
            Filmsitems.Children.Clear();

            //On reconstruit ce tableau 

            for (int i = 0; i < ALL_FILMS.Count(); i++)
            {
                //on instancie un nouveau filmitem
                FilmItem dummyFilmItem = new FilmItem();

                //On le remplit avec les données issues de nos entités (films)
                dummyFilmItem.CodeBarre = ALL_FILMS.ElementAt(i).code_barre.ToString();
                dummyFilmItem.FilmName = ALL_FILMS.ElementAt(i).titre;
                dummyFilmItem.Duree = convert(ALL_FILMS.ElementAt(i).duree);
                dummyFilmItem.Prix = ALL_FILMS.ElementAt(i).prix.ToString();
                dummyFilmItem.EnCommande = ALL_FILMS.ElementAt(i).commandes.ToString();
                dummyFilmItem.EnStock = (ALL_FILMS.ElementAt(i).stock_total - ALL_FILMS.ElementAt(i).exemplaires_loues).ToString();
                dummyFilmItem.EnPret = ALL_FILMS.ElementAt(i).exemplaires_loues.ToString();

                //on instancie un StockState pour afficher en couleur l'état du stocck associé au film
                if ((ALL_FILMS.ElementAt(i).stock_total - ALL_FILMS.ElementAt(i).exemplaires_loues) > 0)
                {
                    dummyFilmItem.Etat = new StockState(0); //positif - en stock
                }
                else
                {
                    dummyFilmItem.Etat = new StockState(2); //nul - rupture
                }

                //On ajoute un évènement de clic souris sur ce FilmItem
                dummyFilmItem.MouseLeftButtonDown += Filmsitems_MouseLeftButtonDown;

                //On concatène tous les genres associés à ce film
                dummyFilmItem.Genre = "";
                for (int j = 0; j < ALL_FILMS.ElementAt(i).Classifications.Count(); j++)
                {
                    dummyFilmItem.Genre += ALL_FILMS.ElementAt(i).Classifications.ElementAt(j).Genre.nom + ";";
                }

                //On ajoute le FilmItem à son élément parent
                Filmsitems.Children.Add(dummyFilmItem);
            }

            //On initialise maintenant la partie haute de la vue
            UpdateSelectedFilm(this.SelectedFilm.code_barre);

        }


        public void UpdateSelectedFilm(long? id)
        {
            //Cette méthode va gérer l'affichage de la partie haute de la vue
            //ici, on récupère toutes les informations associées au film
            //Afin de réinitialiser la vue du dessus.
            //La réaffectation de SelectedFilm est nécéssaire pour le
            //rechargement après modifications entre autres

            this.SelectedFilm = (from film in ALL_FILMS
                        orderby film.Locations.Count() descending
                        where film.code_barre == id
                        select film).First();


            //On remplace les champs du haut par les nouveaux

            TopTitre.Content = this.SelectedFilm.titre + "\n" + this.SelectedFilm.code_barre.ToString();
            TopRealisateur.Content = this.SelectedFilm.Realisateur1.nom;
            TopAnnee.Content = this.SelectedFilm.annee;
            TopDuree.Content = convert(this.SelectedFilm.duree);
            TopPrix.Content = this.SelectedFilm.prix + "€";
            TopStock.Content = this.SelectedFilm.stock_total - this.SelectedFilm.exemplaires_loues;
            TopPrets.Content = this.SelectedFilm.exemplaires_loues;
            TopCommandes.Content = this.SelectedFilm.commandes;
            TopDescription.Text = this.SelectedFilm.synopsis;
            TopImage.Source = new BitmapImage(new Uri("../Components/Assets/" + this.SelectedFilm.image, UriKind.Relative));

            //Ici, l'affichage des genres
            TopGenres.Content = "";
            for (int i = 0; i < this.SelectedFilm.Classifications.Count; i++)
            {
                TopGenres.Content += this.SelectedFilm.Classifications.ElementAt(i).Genre.nom + ";";
            }


            //Ici, l'affichage des voix
            TopVoix.Content = "";
            for (int i = 0; i < this.SelectedFilm.Voixes.Count; i++)
            {

                TopVoix.Content += this.SelectedFilm.Voixes.ElementAt(i).Langue.langue1 + ";";
                
            }


            //Ici, l'affichage des sous_titrages
            TopSoustitres.Content = "";
            for (int i = 0; i < this.SelectedFilm.Sous_titrages.Count; i++)
            {  
                TopSoustitres.Content += this.SelectedFilm.Sous_titrages.ElementAt(i).Langue.langue1 + ";";
            }


            //Ici, l'affichage des acteurs
            TopActeurs.Content = "";
            for (int i = 0; i < this.SelectedFilm.Roles.Count; i++)
            {
                TopActeurs.Content += this.SelectedFilm.Roles.ElementAt(i).Acteur.nom.ToString() + ";"; 
            }


            //On clear les items de locations d'un films (dans la partie haute de la vue)
            ItemsLocations.Children.Clear();

            //On re-crée des listItems appropriés au nouveau film

            for (int i = 0; i < this.SelectedFilm.Locations.Count(); i++)
            {
                //On instancie un FilmLocationItem
                FilmLocationItem dummyLocationItem = new FilmLocationItem();

                //On le remplit
                dummyLocationItem.ClientName = this.SelectedFilm.Locations.ElementAt(i).Client.prenom + this.SelectedFilm.Locations.ElementAt(i).Client.nom;
                dummyLocationItem.LocationStart = this.SelectedFilm.Locations.ElementAt(i).date_debut.ToShortDateString();
                dummyLocationItem.LocationEnd = this.SelectedFilm.Locations.ElementAt(i).date_fin.ToShortDateString();
                if (this.SelectedFilm.Locations.ElementAt(i).rendu)
                {
                    dummyLocationItem.Etat = new LocationState(0);
                }
                else
                {
                    dummyLocationItem.Etat = new LocationState(2);

                }

                //On l'ajoute au stack
                ItemsLocations.Children.Add(dummyLocationItem);
            }
        }
        
        //Cette méthode permet de récupérer le code_barre de l'item du stack (tableau)
        //sur lequel on a cliqué. On appelle ensuite la méthode UpdateSelectedFilm
        //pour actualiser le haut de la vue.
        private void Filmsitems_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FilmItem item = e.Source as FilmItem;
            UpdateSelectedFilm(Int64.Parse(item.CodeBarre));
        }


        //Modale de suppression
        private void BtnDeleteFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_FILMS.Any())
            {
                ModalFilmDelete modal = new ModalFilmDelete(this.SelectedFilm);
                //on lie la vue actuelle afin de pouvoir en appeler les
                //méthodes depuis la modale
                modal.SetFilmView(this);
                //On ajoute la modale à la vue
                FilmMainContainer.Children.Add(modal);
            }
        }



        //Modale de gestion des copies du film
        private void BtnCopiesFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_FILMS.Any())
            {
                ModalFilmCopies modal = new ModalFilmCopies(this.SelectedFilm);
                //on lie la vue actuelle afin de pouvoir en appeler les
                //méthodes depuis la modale
                modal.SetFilmView(this);
                //On ajoute la modale à la vue
                FilmMainContainer.Children.Add(modal);
            }
        }

        //Modale ajout film
        private void BtnAjoutFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_FILMS.Any())
            {
                ModalFilmAdd modal = new ModalFilmAdd();
                //on lie la vue actuelle afin de pouvoir en appeler les
                //méthodes depuis la modale
                modal.SetFilmView(this);
                //On ajoute la modale à la vue
                FilmMainContainer.Children.Add(modal);
            }
        }

        //Méthode associée au bouton Actualiser
        private void BtnRefresh_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ALL_FILMS.Any())
            {
                InitFilms();
            }
        }

        //Non implémenté : édition film (non présent sur CDC)
        //private void BtnEditFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //  ModalFilmEdit modal = new ModalFilmEdit(this.SelectedFilm);
        //FilmMainContainer.Children.Add(modal);
        //}
    }
}
