namespace FinanceMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            EstadoTarjetas = new HashSet<EstadoTarjetas>();
        }

        [Key]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int? DiaVencimiento { get; set; }

        public double LimiteCredito { get; set; }

        public double? LimiteCreditoDollar { get; set; }

        [Required]
        [StringLength(4)]
        public string Numero { get; set; }

        public int UsuarioId { get; set; }

        public int CompaniaTarjetaCreditoId { get; set; }

        public int BancoId { get; set; }

        public virtual Bancos Bancos { get; set; }

        public virtual CompanyTarjetaCreditos CompanyTarjetaCreditos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadoTarjetas> EstadoTarjetas { get; set; }
    }
}
