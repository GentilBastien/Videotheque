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
    }
}
