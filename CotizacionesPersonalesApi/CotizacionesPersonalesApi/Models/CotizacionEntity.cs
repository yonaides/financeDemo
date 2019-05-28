using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class CotizacionEntity
    {
        [Key]
        public int CotizacionId { get; set; }
        public Cliente ClienteId { get; set; }
        public virtual ICollection<CotizacionDetalleEntity> DetalleCotizacionId { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public float MontoTotal { get; set; }
        public int ServiciosTotal { get; set; }

    }
}
