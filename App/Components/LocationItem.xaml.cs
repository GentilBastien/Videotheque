using System.Windows.Controls;

namespace MaVideotheque.Components
{
    
    public partial class LocationItem : UserControl
    {
        public string NumLocation { get; set; }
        public string Titre { get; set; }
        public string NomClient { get; set; }
        public string LocStart { get; set; }
        public string LocEnd { get; set; }
        public string Prix { set; get; }
        public LocationState Etat { set; get; }
        public LocationItem()
        {
            InitializeComponent();
            this.DataContext = this;

            this.Etat = new LocationState(2);
        }
    }
}
