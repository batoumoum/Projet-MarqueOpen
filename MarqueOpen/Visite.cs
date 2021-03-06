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
    
    public partial class Visite
    {
        public Visite()
        {
            this.FactureDueNonPayee = new HashSet<FactureDueNonPayee>();
            this.ListePieceConsommable = new HashSet<ListePieceConsommable>();
            this.OperationVisite = new HashSet<OperationVisite>();
        }
    
        public decimal IdVisite { get; set; }
        public System.DateTime DateEntree { get; set; }
        public decimal NumVisite { get; set; }
        public System.DateTime DateSortie { get; set; }
        public decimal CoutFactureVisite { get; set; }
        public string Descriptif { get; set; }
        public decimal IdPossession { get; set; }
        public decimal IdDevis { get; set; }
    
        public virtual Devis Devis { get; set; }
        public virtual ICollection<FactureDueNonPayee> FactureDueNonPayee { get; set; }
        public virtual ICollection<ListePieceConsommable> ListePieceConsommable { get; set; }
        public virtual ICollection<OperationVisite> OperationVisite { get; set; }
        public virtual Possession Possession { get; set; }
    }
}
