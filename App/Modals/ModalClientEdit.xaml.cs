using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalClientEdit : UserControl
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Adresse { get; set; }
        public ModalClientEdit(string Nom, string Prenom, string Tel, string Mail, string Adresse)
        {
            InitializeComponent();
            this.DataContext = this;

            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Tel = Tel;
            this.Mail = Mail;
            this.Adresse = Adresse;
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
