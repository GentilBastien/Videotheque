using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalLocationEdit : UserControl
    {
        public string Titre { get; set; }
        public string CodeBarre { get; set; }
        public string NumClient { get; set; }
        public string DateDebut { get; set; }
        public string DateFin { get; set; }
        public ModalLocationEdit(string LocationId, string CodeBarre, string NumClient, string DateDebut, string DateFin)
        {
            InitializeComponent();
            this.DataContext = this;

            this.Titre = "Éditer la location n°" + LocationId;
            this.CodeBarre = CodeBarre;
            this.NumClient = NumClient;
            this.DateDebut = DateDebut;
            this.DateFin = DateFin;
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
