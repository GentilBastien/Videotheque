//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaVideotheque
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acteur> Acteurs { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Langue> Langues { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Realisateur> Realisateurs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sous_titrages> Sous_titrages { get; set; }
        public virtual DbSet<Voix> Voixes { get; set; }
    }
}
