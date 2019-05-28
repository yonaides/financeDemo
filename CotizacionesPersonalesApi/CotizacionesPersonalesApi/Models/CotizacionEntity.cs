using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class CotizacionEntity
    {
        public int CotizacionId { get; set; }
        public Cliente ClienteId { get; set; }
        public ICollection<CotizacionDetalleEntity> DetalleCotizacionId { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public float MontoTotal { get; set; }
        public int ServiciosTotal { get; set; }

    }
}
