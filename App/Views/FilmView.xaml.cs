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
    public partial class FilmView : UserControl
    {
        public long selectedFilmId;
        private Film SelectedFilm;
        private ICollection<Location> currentLocations;
        private List<Film> allFilms;
        public FilmItem itemSelected;


        public FilmView()
        {
            InitializeComponent();
            this.DataContext = this;
            InitFilms();
        }


        private void BtnDeleteFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmDelete modal = new ModalFilmDelete(this.SelectedFilm.code_barre,this.SelectedFilm.titre);
            modal.GetFilmView(this);
            FilmMainContainer.Children.Add(modal);
        }
        private void BtnEditFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmEdit modal = new ModalFilmEdit(this.SelectedFilm);
            FilmMainContainer.Children.Add(modal);
        }

        private void BtnCopiesFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmCopies modal = new ModalFilmCopies(this.SelectedFilm.code_barre, this.SelectedFilm.stock_total, this.SelectedFilm.exemplaires_loues, this.SelectedFilm.commandes);
            FilmMainContainer.Children.Add(modal);
        }

        private void BtnAjoutFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmAdd modal = new ModalFilmAdd();
            FilmMainContainer.Children.Add(modal);
        }

        public static String convert(int? mins) //pour convertir les minutes en h:min
        {
            int? hours = (mins - mins % 60) / 60;
            return "" + hours + "h" + (mins - hours * 60);
        }


        public void InitFilms()
        {

            DatabaseEntities dbE = new DatabaseEntities();

            var query = from film in dbE.Films
                         orderby film.Locations.Count() descending
                         select film;

            this.allFilms = query.ToList();
            this.selectedFilmId = query.First().code_barre;
            this.SelectedFilm = query.First();

            UpdateSelectedFilm(this.selectedFilmId);

            for (int i=0;i< Filmsitems.Children.Count; i++)
            {
                Filmsitems.Children.RemoveAt(0);
            }

            //On crée une liste de FilmItem, qui va nous servir à afficher le tableau
            var myFilmItems = new List<FilmItem>();

            //On en instancie autant qu'il faut (ie le nombre de films dans notre BDD)
            for (int i = 0; i < query.Count(); i++)
            {
                myFilmItems.Add(new FilmItem());
            }

            //On crée une liste de StockState, c'est à dire des indications visibles sur l'état du stock.
            //Ce sont des compossants à part entière
            var stockStates = new List<StockState>();

            //On en instancie également autant qu'on a de films
            for (int i = 0; i < query.Count(); i++)
            {
                if ((this.allFilms.ElementAt(i).stock_total - this.allFilms.ElementAt(i).exemplaires_loues) > 0) //On regarde l'état du stock
                {
                    stockStates.Add(new StockState(0)); //positif - en stock
                }
                else
                {
                    stockStates.Add(new StockState(2)); //nul - rupture
                }
            }


            //On parcourt tous les FilmItems de la liste films, puis on les customise
            //suivant les valeurs de la première requête
            for (int i = 0; i < allFilms.Count(); i++)
            {
                myFilmItems.ElementAt(i).CodeBarre = this.allFilms.ElementAt(i).code_barre.ToString();
                myFilmItems.ElementAt(i).FilmName = this.allFilms.ElementAt(i).titre;
                myFilmItems.ElementAt(i).Duree = convert(this.allFilms.ElementAt(i).duree);
                myFilmItems.ElementAt(i).Prix = this.allFilms.ElementAt(i).prix.ToString();
                myFilmItems.ElementAt(i).EnCommande = this.allFilms.ElementAt(i).commandes.ToString();
                myFilmItems.ElementAt(i).EnStock = (this.allFilms.ElementAt(i).stock_total - this.allFilms.ElementAt(i).exemplaires_loues).ToString();
                myFilmItems.ElementAt(i).EnPret = this.allFilms.ElementAt(i).exemplaires_loues.ToString();
                myFilmItems.ElementAt(i).Etat = stockStates.ElementAt(i);

                myFilmItems.ElementAt(i).MouseLeftButtonDown += Filmsitems_MouseLeftButtonDown;

                //On réinitialise genresList à chaque itération
                string genres = "";
                for (int j = 0; j < this.allFilms.ElementAt(i).Classifications.Count(); j++)
                {
                    genres += this.allFilms.ElementAt(i).Classifications.ElementAt(j).Genre.nom + ";";

                    myFilmItems.ElementAt(i).Genre = genres;

                    
                }
                //On ajoute le FilmItem à son élément parent
                Filmsitems.Children.Add(myFilmItems.ElementAt(i));
            }
            

        }

        private void UpdateSelectedFilm(long id)
        {

            DatabaseEntities dbE = new DatabaseEntities();


            //ici, on récupère les informations de la table film (avec le nom du réalisateur à la place de son id en prime)
            var query = from film in dbE.Films
                        orderby film.Locations.Count() descending
                        where film.code_barre == id
                        select film;

            this.SelectedFilm = query.First();

            this.currentLocations = this.SelectedFilm.Locations;

            ItemsLocations.Children.Clear();

            TopTitre.Content = this.SelectedFilm.titre +"\n" + this.SelectedFilm.code_barre.ToString();

            TopRealisateur.Content = this.SelectedFilm.Realisateur1.nom;

            TopAnnee.Content = this.SelectedFilm.annee;

            TopDuree.Content = convert(this.SelectedFilm.duree);

            TopPrix.Content = this.SelectedFilm.prix + "€";

            TopStock.Content = this.SelectedFilm.stock_total - this.SelectedFilm.exemplaires_loues;
             
            TopPrets.Content = this.SelectedFilm.exemplaires_loues;

            TopCommandes.Content = this.SelectedFilm.commandes;

            TopDescription.Text = this.SelectedFilm.synopsis;

            TopImage.Source = new BitmapImage(new Uri("../Components/Assets/"+this.SelectedFilm.image, UriKind.Relative));


            string genres = "";
            for(int i = 0; i < this.SelectedFilm.Classifications.Count; i++)
            {
                genres += this.SelectedFilm.Classifications.ElementAt(i).Genre.nom.ToString()+";";
            }
            TopGenres.Content = genres;

            
            string voix = "";
            for(int i = 0; i < this.SelectedFilm.Voixes.Count; i++)
            {
                voix+=this.SelectedFilm.Voixes.ElementAt(i).Langue.langue1 + ";";
            }
            TopVoix.Content = voix;


            string sous_titres = "";
            for(int i=0; i<this.SelectedFilm.Sous_titrages.Count; i++)
            {
                sous_titres += this.SelectedFilm.Sous_titrages.ElementAt(i).Langue.langue1+";";
            }
            TopSoustitres.Content = sous_titres;


            string acteurs = "";
            for(int i = 0; i < this.SelectedFilm.Roles.Count;i++) { 
                acteurs+= this.SelectedFilm.Roles.ElementAt(i).Acteur.nom.ToString()+";";
            }
            TopActeurs.Content = acteurs;

            //On crée une liste de Location, qui va nous servir à afficher le tableau
            var locationsItems = new List<FilmLocationItem>();

            //On en instancie autant qu'il faut (ie le nombre de films dans notre BDD)
            for (int i = 0; i < this.currentLocations.Count(); i++)
            {
                locationsItems.Add(new FilmLocationItem());
            }

            for (int i = 0; i < this.currentLocations.Count(); i++)
            {
                locationsItems.ElementAt(i).ClientName = this.currentLocations.ElementAt(i).Client.prenom + this.currentLocations.ElementAt(i).Client.nom;
                locationsItems.ElementAt(i).LocationStart = this.currentLocations.ElementAt(i).date_debut.ToShortDateString();
                locationsItems.ElementAt(i).LocationEnd = this.currentLocations.ElementAt(i).date_fin.ToShortDateString();
                if (this.currentLocations.ElementAt(i).rendu)
                {
                    locationsItems.ElementAt(i).Etat = "Rendu";
                }
                else
                {
                    locationsItems.ElementAt(i).Etat = "Non rendu";

                }
                ItemsLocations.Children.Add(locationsItems.ElementAt(i));
            }


        }

            private void Filmsitems_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement s = sender as FrameworkElement;
            FilmItem item = e.Source as FilmItem;
            long selectedBarcode = Int64.Parse(item.CodeBarre);
            this.selectedFilmId = selectedBarcode;
            this.itemSelected = item;
            UpdateSelectedFilm(this.selectedFilmId);
            

        }

    }
}
