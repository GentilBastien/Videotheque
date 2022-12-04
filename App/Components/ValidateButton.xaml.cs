using System.Windows.Controls;

namespace MaVideotheque.Components
{
    public partial class ValidateButton : UserControl
    {
        public string Msg { get; set; }
        public ValidateButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
