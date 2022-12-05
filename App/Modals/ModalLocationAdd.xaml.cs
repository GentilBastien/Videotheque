using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    
    public partial class ModalLocationAdd : UserControl
    {
        public string Msg { get; set; }
        public ModalLocationAdd(string ClientNom, string ClientPrenom)
        {
            InitializeComponent();
            this.DataContext = this;

            this.Msg = "Location de film pour " + ClientNom + " " + ClientPrenom;
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
            //TODO
            this.Visibility = Visibility.Collapsed;
        }
    }
}
