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
        public List<Film> allFilms;
        public List<Film> selectedFilms;
        public HomeView()
        {
            InitializeComponent();
            this.DataContext = this;
            InitFilms();
        }
        public void InitFilms()
        {
            DatabaseEntities myEntities = new DatabaseEntities();
            var query = from film in myEntities.Films select film;
            this.allFilms = query.ToList();
        }

        private void ValidateButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var query1 = (from film in this.allFilms where film.titre.Contains(this.InputTitre.Text) select film)
                .Intersect(from film in this.allFilms where film.Realisateur1.nom.Contains(this.InputRealisateur.Text) select film)
                .Intersect(from film in this.allFilms where film.annee < int.Parse(this.InputBefore.Text) select film)
                .Intersect(from film in this.allFilms where film.annee >= int.Parse(this.InputAfter.Text) select film);

            //var QueryedFilms = query1.Intersect(query2).Intersect(query3).Intersect(query3);

            myStack.Children.Clear();
            RenderSelectedFilms(query1.ToList());
            
        }

        public void RenderSelectedFilms(List<Film> pre_selected_films)
        {

           
           
            this.selectedFilms = pre_selected_films;

            foreach(Film film in this.selectedFilms)
            {
                CaseFilm zaza = new CaseFilm();
                zaza.Annee_film = film.annee.ToString();
                zaza.Nom_film = film.titre;
                zaza.SrcImg = film.image;
                zaza.Real_film = film.Realisateur1.nom;
                //this.myGrid.Children.Insert(0, zaza);
                this.myStack.Children.Add(zaza);
            }
        }

        
    }
}
