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
        public long id;
        public string titre;
        public string realisateur;
        public int duree;
        public int stock_disponible;
        public int stock_total;
        public int exemplaires_loues;
        public int commandes;
        public int annee;
        public double prix;
        public string image;
        public string synopsis;
        public string genres;
        public string acteurs;
        public string voix;
        public string sous_titres;


        public FilmView()
        {
            InitializeComponent();
            this.DataContext = this;
            OnSelectFilm(1994269127125);
            InitFilms();
        }


        private void BtnDeleteFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmDelete modal = new ModalFilmDelete(this.id,this.titre);
            FilmMainContainer.Children.Add(modal);
        }
        private void BtnEditFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmEdit modal = new ModalFilmEdit(this.id,this.titre,this.realisateur,this.duree,this.annee,this.prix,this.image,this.synopsis,this.genres,this.acteurs,this.voix,this.sous_titres);
            FilmMainContainer.Children.Add(modal);
        }

        private void BtnCopiesFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmCopies modal = new ModalFilmCopies(this.stock_total, this.exemplaires_loues, this.commandes);
            FilmMainContainer.Children.Add(modal);
        }

        private void BtnAjoutFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmAdd modal = new ModalFilmAdd();
            FilmMainContainer.Children.Add(modal);
        }

        public static String convert(int mins) //pour convertir les minutes en h:min
        {
            int hours = (mins - mins % 60) / 60;
            return "" + hours + "h" + (mins - hours * 60);
        }

        public void InitFilms()
        {

            //On charge les TabmeAdapters associés à notre DataSet
            FilmsTableAdapter dataFilmEntities = new FilmsTableAdapter();
            GenresTableAdapter dataGenreEntities = new GenresTableAdapter();
            ClassificationsTableAdapter dataClassificationEntities = new ClassificationsTableAdapter();

            //on commence par charger les données brutes
            var query = from film in dataFilmEntities.GetData() select new { film.code_barre, film.titre, duree = convert(film.duree), prix = film.prix + "€", film.stock_total, stockrestant = film.stock_total - film.exemplaires_loues, film.exemplaires_loues, film.commandes };


            

            //Ici, on récupère tous les genres qui catégorisent le film
            var query2 = from genre in dataGenreEntities.GetData()
                         join classification in dataClassificationEntities.GetData() on genre.id equals classification.id_genre
                         where classification.id_film == query.First().code_barre
                         select new { genre.nom };


            //On définit les genres comme une liste d'Arrays
            var genres = new List<Array>();

            
            //Ici, on récupère les genres associés à chaque film obtenu via la requête
            //On parcourt les résultats de la première requête en itérant sur le code barre des films
            //On ajoute ensuite l'array obtenu dans la liste définie ci-dessus
            for (int i = 0; i < query.Count(); i++)
            {
                var query3 = from genre in dataGenreEntities.GetData()
                         join classification in dataClassificationEntities.GetData() on genre.id equals classification.id_genre
                         where classification.id_film == query.ElementAt(i).code_barre
                         select new { nom = genre.nom };

                genres.Add(query3.ToArray());
                
            }

            
            //On crée une liste de FilmItem, qui va nous servir à afficher le tableau
            var films = new List<FilmItem>();

            //On en instancie autant qu'il faut (ie le nombre de films dans notre BDD)
            for (int i = 0; i < query.Count(); i++)
            {
                films.Add(new FilmItem());
            }

            //On crée une liste de StockState, c'est à dire des indications visibles sur l'état du stock.
            //Ce sont des compossants à part entière
            var stockStates = new List<StockState>();

            //On en instancie également autant qu'on a de films
            for (int i = 0; i < query.Count(); i++)
            {
                if (query.ElementAt(i).stockrestant > 0) //On regarde l'état du stock
                {
                    stockStates.Add(new StockState(0)); //positif - en stock
                }
                else
                {
                    stockStates.Add(new StockState(2)); //nul - rupture
                }
            }


            //On initialise une chaîne de caractères qui va contenir les genres
            //d'un film donné à un instant t de la boucle ci-dessous
            string genresList;

            //On initialise une variable entière a
            //Pour simplifier nos calculs
            int a;

            //On parcourt tous les FilmItems de la liste films, puis on les customise
            //suivant les valeurs de la première requête
            for (int i = 0; i < query.Count(); i++)
            {
                films.ElementAt(i).CodeBarre = query.ElementAt(i).code_barre.ToString();
                films.ElementAt(i).FilmName = query.ElementAt(i).titre;
                films.ElementAt(i).Duree = query.ElementAt(i).duree;
                films.ElementAt(i).Prix = query.ElementAt(i).prix;
                films.ElementAt(i).EnCommande = query.ElementAt(i).commandes.ToString();
                films.ElementAt(i).EnStock = query.ElementAt(i).stockrestant.ToString();
                films.ElementAt(i).EnPret = query.ElementAt(i).exemplaires_loues.ToString();
                films.ElementAt(i).Etat = stockStates.ElementAt(i);

                films.ElementAt(i).MouseLeftButtonDown += Filmsitems_MouseLeftButtonDown;

                //On réinitialise genresList à chaque itération
                genresList = "";
                a = 0;

                //On récupère maintenant les genres de l'array sous forme
                //de chaîne de caractères
                for (int j = 0; j<genres.ElementAt(i).Length;j++)
                {
                    //On se débarrasse des caractères superflus
                    //la chaîne est de la forme { nom = Aventure }
                    //On va alors découper la chaîne et extraire les informations
                    //Dans les faits : on retire les 8 premiers caractères et les 2 derniers
                    //La chaîne sera diminuée de 10 caractères : cette longueur est la valeur de a
                    a = genres.ElementAt(i).GetValue(j).ToString().Length-10; 
                    genresList += genres.ElementAt(i).GetValue(j).ToString().Substring(8,a)+";";
                }

                genresList = genresList.Substring(0,genresList.Length);
                //On ajoute la concaténation des genres à l'élément FilmItem
                films.ElementAt(i).Genre = genresList;

                

                //On ajoute le FilmItem à son élément parent
                Filmsitems.Children.Add(films.ElementAt(i));
            }
        }

        private void OnSelectFilm(long id)
        {
            

            FilmsTableAdapter dataFilmEntities = new FilmsTableAdapter();
            ClientsTableAdapter dataClientEntities = new ClientsTableAdapter();
            LocationsTableAdapter dataLocationEntities = new LocationsTableAdapter();
            RealisateursTableAdapter dataRealisateurEntities = new RealisateursTableAdapter();
            ActeursTableAdapter dataActeurEntities = new ActeursTableAdapter();
            RolesTableAdapter dataRoleEntities = new RolesTableAdapter();
            GenresTableAdapter dataGenreEntities = new GenresTableAdapter();
            ClassificationsTableAdapter dataClassificationEntities = new ClassificationsTableAdapter();
            LanguesTableAdapter dataLangueEntitites = new LanguesTableAdapter();
            VoixTableAdapter dataVoixEntities = new VoixTableAdapter();
            Sous_titragesTableAdapter dataSous_titrageEntities = new Sous_titragesTableAdapter();

            //ici, on récupère les informations de la table film (avec le nom du réalisateur à la place de son id en prime)
            var query1 = from film in dataFilmEntities.GetData()
                         join realisateur in dataRealisateurEntities.GetData() on film.realisateur equals realisateur.id
                         where film.code_barre == id
                         select new { film.image, film.code_barre, real = realisateur.nom, film.titre, film.synopsis, film.annee, filmduree=film.duree, duree = convert(film.duree), film.prix, film.stock_total, stock_disponible = film.stock_total - film.exemplaires_loues, film.exemplaires_loues, film.commandes };

            //ici, on récupère tous les noms d'acteur ayant un rôle dans le film
            var query2 = from acteur in dataActeurEntities.GetData()
                         join role in dataRoleEntities.GetData() on acteur.id equals role.id_acteur
                         where role.id_film == id
                         select new { acteur.nom };

            //Ici, on récupère tous les genres qui catégorisent le film
            var query3 = from genre in dataGenreEntities.GetData()
                         join classification in dataClassificationEntities.GetData() on genre.id equals classification.id_genre
                         where classification.id_film == id
                         select new { genre.nom };

            //Ici, on récupère les voix
            var query4 = from langue in dataLangueEntitites.GetData()
                         join voix in dataVoixEntities.GetData() on langue.id equals voix.id_langue
                         where voix.id_film == id
                         select new { langue.langue };


            //Ici, on récupère sous-titrages
            var query5 = from langue in dataLangueEntitites.GetData()
                         join sous_titrage in dataSous_titrageEntities.GetData() on langue.id equals sous_titrage.id_langue
                         where sous_titrage.id_film == id
                         select new { langue.langue };

            //Ici, on récupère toutes les locations associées
            var query6 = from location in dataLocationEntities.GetData()
                         join client in dataClientEntities.GetData() on location.id_client equals client.id
                         where location.id_film == id
                         select new { client.nom, client.prenom, date_debut = location.date_debut.ToShortDateString(), date_fin = location.date_fin.ToShortDateString(), location.rendu };

            this.id = id;
            this.titre = query1.ElementAt(0).titre;
            TopTitre.Content = this.titre + "\n" + this.id.ToString();

            this.realisateur = query1.ElementAt(0).real;
            TopRealisateur.Content = this.realisateur;

            this.annee = query1.ElementAt(0).annee;
            TopAnnee.Content = this.annee;

            this.duree = query1.ElementAt(0).filmduree;
            TopDuree.Content = query1.ElementAt(0).duree;

            this.prix = query1.ElementAt(0).prix;
            TopPrix.Content = this.prix + "€";

            this.stock_total = query1.ElementAt(0).stock_total;
            this.exemplaires_loues  = query1.ElementAt(0).exemplaires_loues;

            this.stock_disponible = query1.ElementAt(0).stock_disponible;
            TopStock.Content = this.stock_disponible;
            TopPrets.Content = this.exemplaires_loues;

            this.commandes = query1.ElementAt(0).commandes;
            TopCommandes.Content = this.commandes;

            this.synopsis = query1.ElementAt(0).synopsis;
            TopDescription.Text = this.synopsis;

            this.image = "../Components/Assets/" + query1.ElementAt(0).image;
            TopImage.Source = new BitmapImage(new Uri(this.image, UriKind.Relative));

            //On définit les genres comme une liste d'Arrays
            string genres = "";
            int ab;
            //Ici, on récupère les genres associés à chaque film obtenu via la requête
            //On parcourt les résultats de la première requête en itérant sur le code barre des films
            //On ajoute ensuite l'array obtenu dans la liste définie ci-dessus
            for (int i = 0; i < query3.Count(); i++)
            {
                genres += query3.ToList().ElementAt(i).nom + ", ";
            }

            genres = genres.Substring(0, genres.Length);
            this.genres = genres;
            TopGenres.Content = genres;

            //On définit les genres comme une liste d'Arrays
            string voixs = "";
            ab = 0;

            //Ici, on récupère les genres associés à chaque film obtenu via la requête
            //On parcourt les résultats de la première requête en itérant sur le code barre des films
            //On ajoute ensuite l'array obtenu dans la liste définie ci-dessus
            for (int i = 0; i < query4.Count(); i++)
            {
                voixs += "l: " + query4.ToList().ElementAt(i).langue + "\n";
            }

            voixs = voixs.Substring(0, voixs.Length);
            this.voix = voixs;
            TopVoix.Content = voixs;


            string sous_titres = "";

            for (int i = 0; i < query5.Count(); i++)
            {
                sous_titres += "st: " + query5.ToList().ElementAt(i).langue + "\n";
            }

            this.sous_titres = sous_titres;
            TopSoustitres.Content = sous_titres;


            string acteurs = "";
            ab = 0;

            for (int i = 0; i < query2.Count(); i++)
            {
                acteurs += query2.ToList().ElementAt(i).nom + "\n";
            }

            this.acteurs = acteurs.Substring(0,acteurs.Length);
            TopActeurs.Content = acteurs;

            //On crée une liste de Location, qui va nous servir à afficher le tableau
            var locations = new List<FilmLocationItem>();

            //On en instancie autant qu'il faut (ie le nombre de films dans notre BDD)
            for (int i = 0; i < query6.Count(); i++)
            {
                locations.Add(new FilmLocationItem());
            }

            for (int i = 0; i < query6.Count(); i++)
            {
                locations.ElementAt(i).ClientName = query6.ElementAt(i).prenom.ToString() + " " + query6.ElementAt(i).nom.ToString();
                locations.ElementAt(i).LocationStart = query6.ElementAt(i).date_debut.ToString();
                locations.ElementAt(i).LocationEnd = query6.ElementAt(i).date_fin.ToString();
                if (query6.ElementAt(i).rendu)
                {
                    locations.ElementAt(i).Etat = "Rendu";
                }
                else
                {
                    locations.ElementAt(i).Etat = "Non rendu";
                    
                }
                ItemsLocations.Children.Add(locations.ElementAt(i));
            }

            

        }

        private void Filmsitems_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement s = sender as FrameworkElement;
            FilmItem item = e.Source as FilmItem;
            long selectedBarcode = Int64.Parse(item.CodeBarre);
            OnSelectFilm(selectedBarcode);
        }

    }
}
