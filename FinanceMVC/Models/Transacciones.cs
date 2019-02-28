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

        public DateTime FechaTransaccion { get; set; }

        public double Monto { get; set; }

        public string Descripcion { get; set; }

        public int TipoTransaccionId { get; set; }

        public int EstadoTarjetaId { get; set; }

        public EstadoTarjetas EstadoTarjetas { get; set; }

        public TipoTransacciones TipoTransacciones { get; set; }
    }
}
