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
    using System.Collections.Generic;
    
    public partial class Role
    {
        public System.Guid id { get; set; }
        public long id_film { get; set; }
        public System.Guid id_acteur { get; set; }
    
        public virtual Acteur Acteur { get; set; }
        public virtual Film Film { get; set; }
    }
}
