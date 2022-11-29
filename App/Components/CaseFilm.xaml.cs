using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class CaseFilm : UserControl
    {
        public string Nom_film { get; set; }
        public string Real_film { get; set; }
        public string Annee_film {get; set; }
        public string Genres_film { set; get; }
        public string SrcImg { set; get; }

        public CaseFilm()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
