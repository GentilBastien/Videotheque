using MaVideotheque.Components;
using MaVideotheque.Views;
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;

namespace MaVideotheque.Modals
{
    public partial class ModalLocationMaj : UserControl
    {
        public string Titre { get; set; }

        public Location maLocation { get; set; }
        public bool rendu { get; set; }

        public LocationView lv = null;
        public ModalLocationMaj(Location maLocation)
        {
            InitializeComponent();
            this.DataContext = this;
            this.maLocation = maLocation;
            this.Titre = "Mettre à jour la location n°" + maLocation.id.ToString();
            this.rendu = maLocation.rendu;

        }

        public void SetLocationView(object parent)
        {
            lv = (LocationView)parent;
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
            String ConnectionString = MainWindow.CONNECTION_STRING;
            int siu;
            if ((bool)this.myCheckbox.IsChecked)
            {
                siu = 1;
            }
            else
            {
                siu = 0;
            }
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("UPDATE Locations SET rendu =" 
                    + siu +" WHERE id like '"+maLocation.id+"'", conn);
                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }

            this.Visibility = Visibility.Collapsed;
        }
    }
}
