using System.Windows.Controls;

namespace MaVideotheque.Components
{
    public partial class CancelButton : UserControl
    {
        public string Msg { get; set; }
        public CancelButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
