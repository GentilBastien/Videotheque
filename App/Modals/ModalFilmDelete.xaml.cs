using LinqToDB.SqlQuery;
using MaVideotheque.DatabaseDataSetTableAdapters;
using MaVideotheque.Views;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;
using UserControl = System.Windows.Controls.UserControl;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmDelete : UserControl
    {
        public string Msg { get; set; }
        public long id { get; set; }
        public Table<FilmsTableAdapter> FilmTab { get; private set; }

        public ModalFilmDelete(long id, string titre)
        {
            InitializeComponent();
            this.DataContext = this;
            this.id = id;
            this.Msg = "Êtes-vous sûr de vouloir supprimer " + titre + " de la liste des films ?";
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
            String ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fbelh\source\repos\Videotheque\App\Database.mdf; Integrated Security = True; Connect Timeout = 30";
            DataContext db = new DataContext(ConnectionString);

            SqlConnection conn = new SqlConnection(ConnectionString);
            string[] querysDelete = {"delete from Classifications where id_film="+this.id,
            "delete from Roles where id_film="+this.id,
            "delete from Voix where id_film="+this.id,
            "delete from Sous_titrages where id_film="+this.id,
            "delete from Locations where id_film="+this.id,
            "delete from Films where code_barre="+this.id };

            List< SqlCommand > commands = new List< SqlCommand >();
            for(int i=0; i<querysDelete.Length; i++)
            {
                commands.Add(conn.CreateCommand());
                commands.ElementAt(i).CommandText = querysDelete[i];
                conn.Open();
                commands.ElementAt(i).ExecuteNonQuery();
                conn.Close();
                db.SubmitChanges();
            }

            db.Connection.Close();
            this.Visibility = Visibility.Collapsed;
        }
    }
}

