using System.Windows.Controls;

namespace MaVideotheque.Components
{
    
    public partial class ClientItem : UserControl
    {
        public string ClientID { get; set; }
        public string ClientPrenom { get; set; }
        public string ClientNom { get; set; }
        public string ClientTel { get; set; }
        public string ClientMail { get; set; }
        public string ClientAdresse { set; get; }
        public string ClientNbLocations { set; get; }
        public ClientItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
