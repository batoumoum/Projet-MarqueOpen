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
    
    public partial class Langue
    {
        public Langue()
        {
            this.LanguePiece = new HashSet<LanguePiece>();
            this.Proprietaire = new HashSet<Proprietaire>();
            this.Concessionnaire = new HashSet<Concessionnaire>();
        }
    
        public decimal CodeLangue { get; set; }
        public string LibelleLangue { get; set; }
    
        public virtual ICollection<LanguePiece> LanguePiece { get; set; }
        public virtual ICollection<Proprietaire> Proprietaire { get; set; }
        public virtual ICollection<Concessionnaire> Concessionnaire { get; set; }
    }
}
