using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmEdit : UserControl
    {
        public string Filmname { get; set; }
        public string Description { get; set; }
        public string Acteurs { get; set; }
        public string Realisateurs { get; set; }
        public string Langues { get; set; }
        public string Release { get; set; }
        public string Duree { get; set; }
        public string Genres { get; set; }
        public string Prix { get; set; }
        public string Path { get; set; }
        public ModalFilmEdit(string Filmname, string Description, string Acteurs, string Realisateurs, string Langues, 
            string Release, string Duree, string Genres, string Prix, string Path)
        {
            InitializeComponent();
            this.DataContext = this;

            this.Filmname = Filmname;
            this.Description = Description;
            this.Acteurs = Acteurs;
            this.Realisateurs = Realisateurs;
            this.Langues = Langues;
            this.Release = Release;
            this.Duree = Duree;
            this.Genres = Genres;
            this.Prix = Prix;
            this.Path = Path;
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
            this.Visibility = Visibility.Collapsed;
        }
    }
}
