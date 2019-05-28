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
        public ICollection<CotizacionDetalleEntity> Detalle { get; set; }
        public float montoTotal { get; set; }
        public int serviciosTotal { get; set; }

    }
}
