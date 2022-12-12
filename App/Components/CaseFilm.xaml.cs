using System.Windows.Controls;

namespace MaVideotheque.Components
{
    public partial class CaseFilm : UserControl
    {
        public string Nom_film { get; set; }
        public string Real_film { get; set; }
        public string Annee_film {get; set; }
        public string Genres_film { set; get; }
        public string Acteurs_film { set; get; }
        public string SrcImg { set; get; }

        public CaseFilm()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
