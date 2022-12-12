using MaVideotheque.Modals;
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

namespace MaVideotheque.Views
{
    public partial class LocationView : UserControl
    {
        public static List<Location> ALL_LOCATIONS { get; set; }

        public LocationView()
        {
            InitializeComponent();

            DatabaseEntities entities = new DatabaseEntities();
            var query3 = from location in entities.Locations
                         orderby location.rendu
                         ascending
                         select location;

            ALL_LOCATIONS = query3.ToList();
        }

        private void BtnCancelLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalLocationDelete modal = new ModalLocationDelete("65465846");
            LocationMainContainer.Children.Add(modal);
        }

        private void BtnEditLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalLocationEdit modal = new ModalLocationEdit("562106051", "56464-az65e5-az65ezre56-zea5r", "458952", "14/05/2001", "21/08/2001");
            LocationMainContainer.Children.Add(modal);
        }

        private void BtnMajLocation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModalLocationMaj modal = new ModalLocationMaj("546545252");
            LocationMainContainer.Children.Add(modal);
        }
    }
}
