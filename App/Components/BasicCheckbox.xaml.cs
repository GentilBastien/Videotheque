using MaVideotheque.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaVideotheque.Components
{
    /// <summary>
    /// Logique d'interaction pour BasicCheckbox.xaml
    /// </summary>
    
    public partial class BasicCheckbox : UserControl
    {
        bool BoxIsChecked { get; set; }
        public BasicCheckbox()
        {
            InitializeComponent();
            
        }

    }
}
