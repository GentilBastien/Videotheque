using System.Windows.Controls;

namespace MaVideotheque.Components
{
    
    public partial class FilmItem : UserControl
    {
        public string CodeBarre { get; set; }
        public string FilmName { get; set; }
        public string Duree { get; set; }
        public string Genre { get; set; }
        public string Prix { get; set; }
        public string Etat { set; get; }
        public string EnStock { set; get; }
        public string EnPret { set; get; }
        public string EnCommande { set; get; }
        public FilmItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
