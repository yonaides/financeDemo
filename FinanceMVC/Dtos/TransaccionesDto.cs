using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.Dtos
{
    public class TransaccionesDto
    {
        
        public int TransaccionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public double Monto { get; set; }

        public int TipoTransaccionId { get; set; }

        public int EstadoTarjetaId { get; set; }

        public virtual EstadoTarjetasDto EstadoTarjetasDto { get; set; }

        public virtual TipoTransaccionesDto TipoTransacciones { get; set; }

    }
}