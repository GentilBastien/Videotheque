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

namespace MaVideotheque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush BrushGreen { get; set; }
        public MainWindow()
        {
            BrushGreen = new SolidColorBrush(Color.FromRgb(101, 255, 107));
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemAccueilLabel.Foreground = ItemAccueil.IsSelected ? BrushGreen : Brushes.Black;
            ItemAccueilImage.Source = new BitmapImage(new Uri("img/home" + (ItemAccueil.IsSelected ? "_selected" : "") + ".png", UriKind.Relative));

            ItemClientsLabel.Foreground = ItemClients.IsSelected ? BrushGreen : Brushes.Black;
            ItemClientsImage.Source = new BitmapImage(new Uri("img/clients" + (ItemClients.IsSelected ? "_selected" : "") + ".png", UriKind.Relative));

            ItemFilmsLabel.Foreground = ItemFilms.IsSelected ? BrushGreen : Brushes.Black;
            ItemFilmsImage.Source = new BitmapImage(new Uri("img/films" + (ItemFilms.IsSelected ? "_selected" : "") + ".png", UriKind.Relative));

            ItemLocationsLabel.Foreground = ItemLocations.IsSelected ? BrushGreen : Brushes.Black;
            ItemLocationsImage.Source = new BitmapImage(new Uri("img/locations" + (ItemLocations.IsSelected ? "_selected" : "") + ".png", UriKind.Relative));
        }
    }
}
