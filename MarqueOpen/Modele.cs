//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarqueOpen
{
    using System;
    using System.Collections.Generic;
    
    public partial class Modele
    {
        public Modele()
        {
            this.Type = new HashSet<Type>();
        }
    
        public decimal IdModele { get; set; }
        public string NomModele { get; set; }
        public decimal IdMarque { get; set; }
        public string Descriptif { get; set; }
    
        public virtual Marque Marque { get; set; }
        public virtual ICollection<Type> Type { get; set; }
    }
}
