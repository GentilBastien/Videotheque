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
using System.Linq;
using System.Runtime.CompilerServices;
using MaVideotheque.Components;

namespace MaVideotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    /// 

    public partial class HomeView : UserControl
    {
        public List<Film> selectedFilms;
        public HomeView()
        {
            InitializeComponent();
            this.DataContext = this;
            InitFilms();
            this.InputBefore.Text = "2023";
            this.InputAfter.Text = "1895";
        }
        public void InitFilms()
        {
            DatabaseEntities myEntities = new DatabaseEntities();
            var query = from film in myEntities.Films select film;
            FilmView.ALL_FILMS = query.ToList();
        }

        private void ValidateButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            string[] genres = this.InputGenres.Text.Split(';');
            string[] acteurs = this.InputActeurs.Text.Split(';');



            var query1 = (from film in FilmView.ALL_FILMS where film.titre.Contains(this.InputTitre.Text) select film)
                .Intersect(from film in FilmView.ALL_FILMS where film.Realisateur1.nom.Contains(this.InputRealisateur.Text) select film)
                .Intersect(from film in FilmView.ALL_FILMS where film.annee <= int.Parse(this.InputBefore.Text) select film)
                .Intersect(from film in FilmView.ALL_FILMS where film.annee >= int.Parse(this.InputAfter.Text) select film);

            //var QueryedFilms = query1.Intersect(query2).Intersect(query3).Intersect(query3);
            IEnumerable<Film> query2 = from film in FilmView.ALL_FILMS where film.code_barre == 001004000207774230001 select film;
            
            IEnumerable<Film> query3 = from film in FilmView.ALL_FILMS where film.code_barre == 000104000207774230001 select film;

            var queryGenres = from film in FilmView.ALL_FILMS select film;
            var queryActeurs = queryGenres;


            foreach (string g in genres)
            {
                foreach (Film f in FilmView.ALL_FILMS)
                {
                    for (int i = 0; i < f.Classifications.Count(); i++)
                    {
                        if(f.Classifications.ElementAt(i).Genre.nom == g)
                        {
                            query2 = query2.Union( from film in FilmView.ALL_FILMS where film == f select film);
                        }

                    }
                }
                queryGenres = queryGenres.Intersect(query2);
                query2 = from film in FilmView.ALL_FILMS where film.code_barre == 001004000207774230001 select film;
            }





            foreach (string a in acteurs)
            {
                foreach (Film f in FilmView.ALL_FILMS)
                {
                    for (int i = 0; i < f.Roles.Count(); i++)
                    {
                        if (f.Roles.ElementAt(i).Acteur.nom == a)
                        {
                            query3 = query3.Union(from film in FilmView.ALL_FILMS where film == f select film);
                        }
                    }
                }
                queryActeurs = queryActeurs.Intersect(query3);
                query3 = from film in FilmView.ALL_FILMS where film.code_barre == 001004000207774230001 select film;
            }

            

            
            if (this.InputGenres.Text != ""){
                query1 = query1.Intersect(queryGenres);
            }

            if (this.InputActeurs.Text != "")
            {
                query1 = query1.Intersect(queryActeurs);
            }

            myStack.Children.Clear();
            
            RenderSelectedFilms(query1.ToList());
            
        }

        public string GetGenres(Film myFilm)
        {
            string genres = "";
            foreach(Classification c in myFilm.Classifications)
            {
                genres += c.Genre.nom+";";
            }

            return genres;
        }
        public string GetActeurs(Film myFilm)
        {
            string acteurs = "";
            foreach (Role c in myFilm.Roles)
            {
                acteurs += c.Acteur.nom +";";
            }

            return acteurs;
        }
        public void RenderSelectedFilms(List<Film> pre_selected_films)
        {

           
            this.selectedFilms = pre_selected_films;
            this.FilmsCount.Content = this.selectedFilms.Count + " Résultat(s) trouvé(s) !"; 

            
            foreach(Film film in this.selectedFilms)
            {
                CaseFilm maCaseFilm = new CaseFilm();
                maCaseFilm.Annee_film = film.annee.ToString();
                maCaseFilm.Nom_film = film.titre;
                maCaseFilm.SrcImg = "../Components/Assets/" + film.image;
                
                maCaseFilm.Real_film = film.Realisateur1.nom;
                maCaseFilm.Genres_film = GetGenres(film);
                maCaseFilm.Acteurs_film = GetActeurs(film);
                this.myStack.Children.Add(maCaseFilm);
            }
        }

        
    }
}
