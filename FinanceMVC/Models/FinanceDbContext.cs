namespace FinanceMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class FinanceDbContext : DbContext
    {
        public FinanceDbContext(): base("name=FinanceDbContext")
        {
        }

        public virtual DbSet<Bancos> Bancos { get; set; }
        public virtual DbSet<CompanyTarjetaCreditos> CompanyTarjetaCreditos { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EstadoTarjetas> EstadoTarjetas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TipoTransacciones> TipoTransacciones { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bancos>()
                .Property(e => e.NombreBanco)
                .IsUnicode(false);

            modelBuilder.Entity<Bancos>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Bancos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyTarjetaCreditos>()
                .Property(e => e.NombreCompany)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyTarjetaCreditos>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.CompanyTarjetaCreditos)
                .HasForeignKey(e => e.CompaniaTarjetaCreditoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estados>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Estados>()
                .HasMany(e => e.CompanyTarjetaCreditos)
                .WithRequired(e => e.Estados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoTarjetas>()
                .HasMany(e => e.Transacciones)
                .WithRequired(e => e.EstadoTarjetas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.EstadoTarjetas)
                .WithRequired(e => e.Productos)
                .HasForeignKey(e => e.ProductosId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoTransacciones>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<TipoTransacciones>()
                .HasMany(e => e.Transacciones)
                .WithRequired(e => e.TipoTransacciones)
                .WillCascadeOnDelete(false);
        }
    }
}
