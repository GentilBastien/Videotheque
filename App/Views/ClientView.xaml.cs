using MaVideotheque.Modals;
using System.Reflection;
using System.Windows.Controls;

namespace MaVideotheque.Views
{
    public partial class ClientView : UserControl
    {
        public Client selectedClient;
        public ClientView()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void BtnDeleteClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientDelete modal = new ModalClientDelete("Pierre");
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnEditClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientEdit modal = new ModalClientEdit("ROISSY", "Pierre", "0648755669", "roissy.pierre@gmail.com", "3 allée des roses");
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnFactureClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientFacture modal = new ModalClientFacture("ROISSY", "Pierre");
            ClientMainContainer.Children.Add(modal);
        }

        private void BtnLouerFilm_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalLocationAdd modal = new ModalLocationAdd("ROISSY", "Pierre");
            ClientMainContainer.Children.Add(modal);
        }
    }
}
