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
    
    public partial class Jante
    {
        public Jante()
        {
            this.Vehicule = new HashSet<Vehicule>();
        }
    
        public decimal CodeJante { get; set; }
        public decimal Pouce { get; set; }
    
        public virtual ICollection<Vehicule> Vehicule { get; set; }
    }
}
