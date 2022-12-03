using System.Windows.Controls;

namespace MaVideotheque.Components
{
    public partial class ClientLocationItem : UserControl
    {
        public string FilmId { get; set; }
        public string FilmName { get; set; }
        public string LocationStart { get; set; }
        public string LocationEnd { set; get; }
        public string Etat { set; get; }
        public ClientLocationItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
