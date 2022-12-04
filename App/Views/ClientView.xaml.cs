using MaVideotheque.Modals;
using System.Windows.Controls;

namespace MaVideotheque.Views
{
    public partial class ClientView : UserControl
    {
        public ClientView()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void BtnDeleteClient_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModalClientDelete modal = new ModalClientDelete("Pierre");
            mainContainer.Children.Add(modal);
        }
    }
}
