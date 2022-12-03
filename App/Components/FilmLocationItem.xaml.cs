using System.Windows.Controls;

namespace MaVideotheque.Components
{
    public partial class FilmLocationItem : UserControl
    {
        public string ClientName { get; set; }
        public string LocationStart { get; set; }
        public string LocationEnd { set; get; }
        public string Etat { set; get; }
        public FilmLocationItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
