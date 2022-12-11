using MaVideotheque.Components;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalClientAdd : UserControl
    {
        public ModalClientAdd()
        {
            InitializeComponent();
            this.DataContext = this;
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
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(
                "INSERT INTO Clients " +
                "VALUES (@Id, @Nom, @Prenom, @Mail, @Telephone, @Adresse, @DateNaissance)", conn);
                                
                command.Parameters.AddWithValue("@Id", System.Guid.NewGuid());
                command.Parameters.AddWithValue("@Nom", InputNom.Text);
                command.Parameters.AddWithValue("@Prenom", InputPrenom.Text);
                command.Parameters.AddWithValue("@Mail", InputMail.Text);
                command.Parameters.AddWithValue("@Telephone", InputTel.Text);
                command.Parameters.AddWithValue("@Adresse", InputAdresse.Text);
                command.Parameters.AddWithValue("@DateNaissance", InputDateNaissance.Text);

                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }


            
            this.Visibility = Visibility.Collapsed;
        }
    }
}
