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
    
    public partial class LanguePiece
    {
        public decimal CodeLangue { get; set; }
        public decimal Code { get; set; }
        public string TraductionPiece { get; set; }
    
        public virtual Langue Langue { get; set; }
        public virtual PieceConsommable PieceConsommable { get; set; }
    }
}
