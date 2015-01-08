﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MarqueOpenEntities : DbContext
    {
        public MarqueOpenEntities()
            : base("name=MarqueOpenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Concessionnaire> Concessionnaire { get; set; }
        public virtual DbSet<DegreQualification> DegreQualification { get; set; }
        public virtual DbSet<Devis> Devis { get; set; }
        public virtual DbSet<FactureDueNonPayee> FactureDueNonPayee { get; set; }
        public virtual DbSet<Jante> Jante { get; set; }
        public virtual DbSet<Langue> Langue { get; set; }
        public virtual DbSet<LanguePiece> LanguePiece { get; set; }
        public virtual DbSet<LieuStockage> LieuStockage { get; set; }
        public virtual DbSet<Ligne> Ligne { get; set; }
        public virtual DbSet<LigneCommentaire> LigneCommentaire { get; set; }
        public virtual DbSet<LigneOperation> LigneOperation { get; set; }
        public virtual DbSet<LignePiece> LignePiece { get; set; }
        public virtual DbSet<ListePieceConsommable> ListePieceConsommable { get; set; }
        public virtual DbSet<Marque> Marque { get; set; }
        public virtual DbSet<Modele> Modele { get; set; }
        public virtual DbSet<NumTelOuvrier> NumTelOuvrier { get; set; }
        public virtual DbSet<NumTelProprio> NumTelProprio { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<OperationVisite> OperationVisite { get; set; }
        public virtual DbSet<OptionV> OptionV { get; set; }
        public virtual DbSet<Ouvrier> Ouvrier { get; set; }
        public virtual DbSet<PieceConsommable> PieceConsommable { get; set; }
        public virtual DbSet<Possession> Possession { get; set; }
        public virtual DbSet<Proprietaire> Proprietaire { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Vehicule> Vehicule { get; set; }
        public virtual DbSet<Visite> Visite { get; set; }
    }
}
