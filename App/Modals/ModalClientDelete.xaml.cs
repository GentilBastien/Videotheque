using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalClientDelete : UserControl
    {
        public string Msg { get; set; }
        public ModalClientDelete(string ClientName)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Msg = "Êtes-vous sûr de vouloir supprimer " + ClientName + " de la liste des clients ?";
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
