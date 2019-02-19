namespace FinanceMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transacciones
    {
        [Key]
        public int TransaccionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public double Monto { get; set; }

        public int TipoTransaccionId { get; set; }

        public int EstadoTarjetaId { get; set; }

        public virtual EstadoTarjetas EstadoTarjetas { get; set; }

        public virtual TipoTransacciones TipoTransacciones { get; set; }
    }
}
