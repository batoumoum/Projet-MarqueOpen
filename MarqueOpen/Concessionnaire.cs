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
    
    public partial class Concessionnaire
    {
        public Concessionnaire()
        {
            this.Langue = new HashSet<Langue>();
        }
    
        public decimal IdConcessionnaire { get; set; }
        public string NomConcessionnaire { get; set; }
        public string Adr_Rue { get; set; }
        public decimal Adr_Numero { get; set; }
        public decimal IdMarque { get; set; }
    
        public virtual Marque Marque { get; set; }
        public virtual ICollection<Langue> Langue { get; set; }
    }
}
