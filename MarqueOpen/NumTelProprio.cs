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
    
    public partial class NumTelProprio
    {
        public decimal IdNumTelProprio { get; set; }
        public decimal NumTelProprio1 { get; set; }
        public decimal IdProprietaire { get; set; }
    
        public virtual Proprietaire Proprietaire { get; set; }
    }
}
