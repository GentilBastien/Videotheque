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

namespace MaVideotheque.Views
{
    public partial class FilmView : UserControl
    {
        public FilmView()
        {
            InitializeComponent();
        }

        private void BtnDeleteFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmDelete modal = new ModalFilmDelete("Harry Potter à l'école des sorciers");
            FilmMainContainer.Children.Add(modal);
        }

        private void BtnEditFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmEdit modal = new ModalFilmEdit("Harry Potter à l'école des sorciers", "C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de C'est l'histoire de", "Daniel Radcliff;Emma Watson;Bourvil", "Chris Columbus", "Français;Anglais", "2001", "2h04", "Action;Sci-Fi", "13€", "../Components/Assets/harry_2.png");
            FilmMainContainer.Children.Add(modal);
        }

        private void BtnCopiesFilm_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalFilmCopies modal = new ModalFilmCopies(20, 12, 5);
            FilmMainContainer.Children.Add(modal);
        }
    }
}
