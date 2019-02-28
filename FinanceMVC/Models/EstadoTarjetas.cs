namespace FinanceMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EstadoTarjetas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadoTarjetas()
        {
            Transacciones = new HashSet<Transacciones>();
        }

        [Key]
        public int EstadoTarjetaId { get; set; }

        public DateTime? FechaEstado { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public double BalancePendiente { get; set; }

        public int ProductosId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Productos Productos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Transacciones> Transacciones { get; set; }
    }
}
