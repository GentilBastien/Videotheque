using MaVideotheque.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Media.Animation;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace MaVideotheque.Modals
{
    public partial class ModalFilmAdd : UserControl
    {
        public FilmView fv = null;
        public Realisateur monRealisateur { get; set; }
        public List<Genre> mesGenres { get;set; }
        public List<Classification> mesClassifications { get; set; }
        public List<Acteur> mesActeurs { get; set; }
        public List<Role> mesRoles { get; set; }
        public List<Langue> mesLanguesST { get; set; }
        public List<Langue> mesLanguesVoix { get; set; }
        public List<Voix> mesVoix { get; set; }
        public List<Sous_titrages> mesSousTitrages { get; set; }
        public Film monFilm {get; set;}

        public ModalFilmAdd()
        {
            InitializeComponent();
            this.DataContext = this;
            this.mesGenres = new List<Genre>();
            this.mesActeurs = new List<Acteur>();
            this.mesRoles = new List<Role>();
            this.mesLanguesST = new List<Langue>();
            this.mesLanguesVoix = new List<Langue>();
            this.mesSousTitrages = new List<Sous_titrages>();
            this.mesVoix = new List<Voix>();
            this.mesClassifications = new List<Classification>();
            //Le film de l'on va ajouter dans FilmView.ALL_FILMS
            this.monFilm = new Film();
        }

        //On lie la modale à la FilmView
        public void SetFilmView(object parent)
        {
            fv = (FilmView)parent;
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

            DatabaseEntities entities = new DatabaseEntities();
            
            //On commence par récupérer toutes les données du formulaire,
            //Et à les parse dans les bons types
            long CodeBarre = Int64.Parse(this.InputBarcode.Text);
            string Titre = this.InputFilmname.Text;
            string Synopsis = this.InputDescription.Text;
            string Realisateur = this.InputReal.Text;
            int Annee = Int32.Parse(this.InputRelease.Text);
            int Duree = Int32.Parse(this.InputDuree.Text);
            int Prix = Int32.Parse(this.InputPrix.Text);
            string Image = this.InputPath.Text;

            //On récupère entre autres la liste des genres, acteurs, voix et sous-titrages
            string[] Acteurs = InputActeurs.Text.Split(';');
            string[] Genres = InputGenres.Text.Split(';');
            string[] Voix = InputVoix.Text.Split(';');
            string[] Sous_titres = InputSoustitres.Text.Split(';');
         

            //si le film existe déjà
            if ((from film in FilmView.ALL_FILMS where film.code_barre == CodeBarre select film).Count() != 0)
            {
                this.Visibility = Visibility.Collapsed;
            }

            //Si le réalisateur entré est pré-existant dans la BDD
            if ((from film in FilmView.ALL_FILMS where film.Realisateur1.nom == Realisateur select film).Count() != 0)
            {
                this.monRealisateur = (from realisateur in entities.Realisateurs where realisateur.nom == Realisateur select realisateur).First();
            }
            else //sinon, on l'ajoute dans la BDD
            {
                //On crée l'objet
                this.monRealisateur = new Realisateur();
                this.monRealisateur.id = System.Guid.NewGuid();
                this.monRealisateur.nom = Realisateur;

                using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand(
                    "INSERT INTO Realisateurs " + "VALUES (@Id, @Nom)", conn);

                    command.Parameters.AddWithValue("@Id", this.monRealisateur.id);
                    command.Parameters.AddWithValue("@Nom", this.monRealisateur.nom);

                    adapter.InsertCommand = command;
                    conn.Open();
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }

            //Dans tous les cas, on ajoute le réalisateur au film créé :
            //On se doit d'aller jusqu'aux tables imbriquées pour satisfaire
            //L'ensemble des requêtes faites par le logiciel
            this.monFilm.Realisateur1 = monRealisateur;
            this.monFilm.realisateur = monRealisateur.id;

            //On passe maintenant aux acteurs
            //Le but est de vérifier si pour chaque acteur entré
            //s'il existe déjà en BDD. Si ce n'est pas le cas,
            //on l'insère à la volée dans la BDD.

            foreach (string a in Acteurs)
            {
                if (a != "")
                {
                    bool isAct = false; //On initialise un booléen

                    //On instancie un nouvel acteur
                    Acteur Act = new Acteur();

                    //On charge et passe en revue tous les rôles de nos entités
                    var query = from film in FilmView.ALL_FILMS select new { film.Roles };

                    for (int i = 0; i < query.Count(); i++)
                    {
                        for (int j = 0; j < query.ElementAt(i).Roles.Count(); j++)
                        {
                            if (query.ElementAt(i).Roles.ElementAt(j).Acteur.nom == a)
                            {
                                isAct = true; //si le nom est présent dans la liste
                                Act = query.ElementAt(i).Roles.ElementAt(j).Acteur; //on récupère l'objet Acteur associé
                            }
                        }

                    }

                    //Dans tous les cas un rôle est crée
                    Role rol = new Role();
                    rol.id = System.Guid.NewGuid();
                    rol.id_film = CodeBarre;

                    if (isAct)
                    {
                        //Si l'on a récupéré l'objet acteur
                        rol.id_acteur = Act.id;
                        rol.Acteur = Act; //On l'imbrique dans notre objet rôle
                    }
                    else
                    {
                        //Si l'acteur n'était pas dans la BDD : 
                        Act.id = System.Guid.NewGuid(); //on lui attribue un nouvel id
                        Act.nom = a; //On récupère son nom
                        rol.id_acteur = Act.id; //on insère son id dans le Role
                        rol.Acteur = Act; //on l'insère entièrement dans le Role
                        Act.Roles.Add(rol); //on lui ajoute l'objet Role le contenant
                        mesActeurs.Add(Act); //on l'ajoute enfin à notre liste d'acteurs

                        using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            SqlCommand command = new SqlCommand(
                            "INSERT INTO Acteurs " + "VALUES (@Id, @Nom)", conn);

                            command.Parameters.AddWithValue("@Id", Act.id);
                            command.Parameters.AddWithValue("@Nom", Act.nom);

                            adapter.InsertCommand = command;
                            conn.Open();
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                    }

                    monFilm.Roles.Add(rol); //on ajoute le role créé au film crée
                    mesRoles.Add(rol); //on l'ajoute également à la liste des roles pour une insertion future
                }
            }


            //La procédure est exactement la même que pour les Acteurs/Roles,
            //mais pour les Genres/Classifications (symétrie de la BDD)
            foreach (string g in Genres)
            {
                if (g != "")
                {

                    bool isGenr = false;
                    Genre Genr = new Genre();
                    var query2 = from film in FilmView.ALL_FILMS select new { film.Classifications };
                    for (int i = 0; i < query2.Count(); i++)
                    {
                        for (int j = 0; j < query2.ElementAt(i).Classifications.Count(); j++)
                        {
                            if (query2.ElementAt(i).Classifications.ElementAt(j).Genre.nom == g)
                            {
                                isGenr = true;
                                Genr = query2.ElementAt(i).Classifications.ElementAt(j).Genre;
                            }
                        }

                    }
                    Classification classif = new Classification();
                    classif.id = System.Guid.NewGuid();
                    classif.id_film = CodeBarre;

                    if (isGenr)
                    {
                        classif.id_genre = Genr.id;
                        classif.Genre = Genr;
                        classif.Genre.nom = g;
                    }
                    else
                    {
                        Genr.id = System.Guid.NewGuid();
                        Genr.nom = g;
                        classif.id_genre = Genr.id;
                        classif.Genre = Genr;
                        classif.Genre.nom = g;
                        Genr.Classifications.Add(classif);
                        mesGenres.Add(Genr);

                        using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            SqlCommand command = new SqlCommand(
                            "INSERT INTO Genres " + "VALUES (@Id, @Nom)", conn);

                            command.Parameters.AddWithValue("@Id", Genr.id);
                            command.Parameters.AddWithValue("@Nom", Genr.nom);

                            adapter.InsertCommand = command;
                            conn.Open();
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                    }

                    monFilm.Classifications.Add(classif);
                    mesClassifications.Add(classif);
                }
            }

            //De même pour les Voix/Langues
            foreach (string v in Voix)
            {
                if (v != "")
                {
                    bool isLang = false;
                    Langue Lang = new Langue();
                    var query3 = from film in FilmView.ALL_FILMS select new { film.Voixes };
                    for (int i = 0; i < query3.Count(); i++)
                    {
                        for (int j = 0; j < query3.ElementAt(i).Voixes.Count(); j++)
                        {
                            if (query3.ElementAt(i).Voixes.ElementAt(j).Langue.langue1 == v)
                            {
                                isLang = true;
                                Lang = query3.ElementAt(i).Voixes.ElementAt(j).Langue;
                            }
                        }

                    }
                    Voix voi = new Voix();
                    voi.id = System.Guid.NewGuid();
                    voi.id_film = CodeBarre;

                    if (isLang)
                    {
                        voi.id_langue = Lang.id;
                        voi.Langue = Lang;
                        voi.Langue.langue1 = v;
                    }
                    else
                    {
                        Lang.id = System.Guid.NewGuid();
                        Lang.langue1 = v;
                        voi.id_langue = Lang.id;
                        voi.Langue = Lang;
                        voi.Langue.langue1 = v;
                        Lang.Voixes.Add(voi);
                        mesLanguesVoix.Add(Lang);

                        using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            SqlCommand command = new SqlCommand(
                            "INSERT INTO Langues " + "VALUES (@Id, @Nom)", conn);

                            command.Parameters.AddWithValue("@Id", Lang.id);
                            command.Parameters.AddWithValue("@Nom", Lang.langue1);

                            adapter.InsertCommand = command;
                            conn.Open();
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                    }

                    monFilm.Voixes.Add(voi);
                    mesVoix.Add(voi);
                }
            }

            //Et pour les Sous_titrages/Langues
            foreach (string st in Sous_titres)
            {
                if (st != "")
                {
                    bool isLang = false;
                    Langue Lang = new Langue();
                    var query4 = from film in FilmView.ALL_FILMS select new { film.Sous_titrages };
                    for (int i = 0; i < query4.Count(); i++)
                    {
                        for (int j = 0; j < query4.ElementAt(i).Sous_titrages.Count(); j++)
                        {
                            if (query4.ElementAt(i).Sous_titrages.ElementAt(j).Langue.langue1 == st)
                            {
                                isLang = true;
                                Lang = query4.ElementAt(i).Sous_titrages.ElementAt(j).Langue;
                            }
                        }

                    }

                    Sous_titrages soust = new Sous_titrages();
                    soust.id = System.Guid.NewGuid();
                    soust.id_film = CodeBarre;

                    if (isLang)
                    {
                        soust.id_langue = Lang.id;
                        soust.Langue = Lang;
                        soust.Langue.langue1 = st;
                    }
                    else
                    {
                        Lang.id = System.Guid.NewGuid();
                        Lang.langue1 = st;
                        soust.id_langue = Lang.id;
                        soust.Langue = Lang;
                        soust.Langue.langue1 = st;
                        Lang.Sous_titrages.Add(soust);
                        mesLanguesST.Add(Lang);

                        using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            SqlCommand command = new SqlCommand(
                            "INSERT INTO Langues " + "VALUES (@Id, @Nom)", conn);

                            command.Parameters.AddWithValue("@Id", Lang.id);
                            command.Parameters.AddWithValue("@Nom", Lang.langue1);

                            adapter.InsertCommand = command;
                            conn.Open();
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                    }

                    mesSousTitrages.Add(soust);
                }
            }

            
            //Nous pouvons enfin insérer notre nouveau film dans la BDD

            using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(
                "INSERT INTO Films " + "VALUES (@CodeBarre, @IdReal, @Titre, @Synopsis, @Annee, @Duree, @Image, 0, 0, 0, @Prix)", conn);

                command.Parameters.AddWithValue("@CodeBarre", CodeBarre);
                command.Parameters.AddWithValue("@IdReal", this.monRealisateur.id);
                command.Parameters.AddWithValue("@Titre", Titre);
                command.Parameters.AddWithValue("@Synopsis", Synopsis);
                command.Parameters.AddWithValue("@Annee", Annee);
                command.Parameters.AddWithValue("@Duree", Duree);
                command.Parameters.AddWithValue("@Image", Image);
                command.Parameters.AddWithValue("@Prix", Prix);
              
                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }

            if(mesClassifications.Count > 0)
            {
                foreach(Classification clas in mesClassifications)
                {
                    using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        SqlCommand command = new SqlCommand(
                        "INSERT INTO Classifications " + "VALUES (@Id,@CodeBarre,@IdGenre)", conn);

                        command.Parameters.AddWithValue("@Id", clas.id);
                        command.Parameters.AddWithValue("@CodeBarre", CodeBarre);
                        command.Parameters.AddWithValue("@IdGenre", clas.id_genre);

                        adapter.InsertCommand = command;
                        conn.Open();
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }
                
            }

            //On insère les rôles de la même manière
            if (mesRoles.Count > 0)
            {
                foreach (Role role in mesRoles)
                {
                    using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        SqlCommand command = new SqlCommand(
                        "INSERT INTO Roles " + "VALUES (@Id,@CodeBarre,@IdActeur)", conn);

                        command.Parameters.AddWithValue("@Id", role.id);
                        command.Parameters.AddWithValue("@CodeBarre", CodeBarre);
                        command.Parameters.AddWithValue("@IdActeur", role.id_acteur);

                        adapter.InsertCommand = command;
                        conn.Open();
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }

            }

            //Les voix
            if (mesVoix.Count > 0)
            {
                foreach (Voix voix in mesVoix)
                {
                    using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        SqlCommand command = new SqlCommand(
                        "INSERT INTO Voix " + "VALUES (@Id,@CodeBarre,@IdLangue)", conn);

                        command.Parameters.AddWithValue("@Id", voix.id);
                        command.Parameters.AddWithValue("@CodeBarre", CodeBarre);
                        command.Parameters.AddWithValue("@IdLangue", voix.id_langue);

                        adapter.InsertCommand = command;
                        conn.Open();
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }

            }

            //Et les sous_titrages
            if (mesSousTitrages.Count > 0)
            {
                foreach (Sous_titrages st in mesSousTitrages)
                {
                    using (SqlConnection conn = new SqlConnection(MainWindow.CONNECTION_STRING))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        SqlCommand command = new SqlCommand(
                        "INSERT INTO [Sous_titrages] " + "VALUES (@Id,@CodeBarre,@IdLangue)", conn);

                        command.Parameters.AddWithValue("@Id", st.id);
                        command.Parameters.AddWithValue("@CodeBarre", CodeBarre);
                        command.Parameters.AddWithValue("@IdLangue", st.id_langue);

                        adapter.InsertCommand = command;
                        conn.Open();
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }

            }

            //On finit par insérer les données "de base" obtenues via le formulaire
            //dans notre objet Film
            this.monFilm.code_barre = CodeBarre;
            this.monFilm.duree = Duree;
            this.monFilm.annee = Annee;
            this.monFilm.commandes = 0;
            this.monFilm.image = Image;
            this.monFilm.prix = Prix;
            this.monFilm.exemplaires_loues = 0;
            this.monFilm.stock_total = 0;
            this.monFilm.titre = Titre;
            this.monFilm.synopsis = Synopsis;

            //On ajoute l'objet à notre collection
            FilmView.ALL_FILMS.Add(monFilm);

            //On recharge la liste des films
            fv.InitFilms();

            //On affiche le film ajouté en haut
            fv.UpdateSelectedFilm(CodeBarre);

            //on fait disparaître la modale
            this.Visibility = Visibility.Collapsed;
        }
    }
}
