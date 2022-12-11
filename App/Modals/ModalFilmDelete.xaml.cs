using LinqToDB;
using LinqToDB.Common;
using LinqToDB.SqlQuery;
using MaVideotheque.Components;
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
using System.Windows.Media.Imaging;
using static LinqToDB.Common.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;
using DataContext = System.Data.Linq.DataContext;
using UserControl = System.Windows.Controls.UserControl;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmDelete : UserControl
    {
        public string Msg { get; set; }
        public long id { get; set; }
        public Table<FilmsTableAdapter> FilmTab { get; private set; }

        public FilmView fv;

        public ModalFilmDelete(long id, string titre)
        {
            InitializeComponent();
            this.DataContext = this;
            this.id = id;
            this.Msg = "Êtes-vous sûr de vouloir supprimer " + titre + " de la liste des films ?";
            this.fv = null;
        }
      
        public void SetFilmView(object parent)
        {
            this.fv = parent as FilmView; // on stocke le parent actuel
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
            
            DataContext db = new DataContext(ConnectionString);

            //using (db)
            //{

            //    var queryclassifications = from classification in fv.entities.Classifications
            //                               where classification.id_film == this.id
            //                               select classification;

            //    var queryroles = from role in fv.entities.Roles
            //                     where role.id_film == this.id
            //                     select role;

            //    var querylocations = from location in fv.entities.Locations
            //                         where location.id_film == this.id
            //                         select location;

            //    var queryvoix = from voix in fv.entities.Voixes
            //                    where voix.id_film == this.id
            //                    select voix;

            //    var queryst = from sous_titrage in fv.entities.Sous_titrages
            //                  where sous_titrage.id_film == this.id
            //                  select sous_titrage;

            //    var queryfilm = (from film in fv.entities.Films
            //                     where film.code_barre == this.id
            //                     select film).First();


            //    fv.entities.Classifications.RemoveRange(queryclassifications);
            //    fv.entities.Roles.RemoveRange(queryroles);
            //    fv.entities.Locations.RemoveRange(querylocations);
            //    fv.entities.Voixes.RemoveRange(queryvoix);
            //    fv.entities.Sous_titrages.RemoveRange(queryst);
            //    fv.entities.Films.Remove(queryfilm);
            //    fv.entities.SaveChanges();
            //}



            SqlConnection conn = new SqlConnection(ConnectionString);
            string[] querysDelete = {"delete from Classifications where id_film="+this.id,
            "delete from Roles where id_film="+this.id,
            "delete from Voix where id_film="+this.id,
            "delete from Sous_titrages where id_film="+this.id,
            "delete from Locations where id_film="+this.id,
            "delete from Films where code_barre="+this.id };

            for (int i = 0; i < querysDelete.Length; i++)
            {
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = querysDelete[i];
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                db.SubmitChanges();
            }

            db.Connection.Close();
            fv.ReloadFilmsAfterDelete();
            this.Visibility = Visibility.Collapsed;

        }
    }
}

