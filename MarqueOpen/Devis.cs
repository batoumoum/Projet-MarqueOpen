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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Devis
    {
        public Devis()
        {
            this.Visite = new HashSet<Visite>();
            this.Ligne = new HashSet<Ligne>();
        }
    
        public decimal IdDevis { get; set; }
        public string NumDevis { get; set; }
        [Required(ErrorMessage = "La date est requise")]
        public System.DateTime Date { get; set; }
        [Required(ErrorMessage = "Desciptif requis")]
        public string Descriptif { get; set; }
        [Required(ErrorMessage = "Le numéro de plaque est requis")]
        public decimal IdPossession { get; set; }
    
        public virtual Possession Possession { get; set; }
        public virtual ICollection<Visite> Visite { get; set; }
        public virtual ICollection<Ligne> Ligne { get; set; }
    }
}
