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

        public DateTime FechaTransaccion { get; set; }

        public double Monto { get; set; }

        public string Descripcion { get; set; }

        public int TipoTransaccionId { get; set; }

        public int EstadoTarjetaId { get; set; }

        public EstadoTarjetasDto EstadoTarjetasDto { get; set; }

        public TipoTransaccionesDto TipoTransacciones { get; set; }

    }
}