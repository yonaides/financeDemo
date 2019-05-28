using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class CotizacionDetalleEntity
    {
        [Key]
        public int CotizacionDetalleId { get; set; }
        public CotizacionEntity CotizacionId { get; set; }
        public ServicioEntity ServicioID { get; set; }
        public float precioServicio { get; set; }
        public int cantidadServicio { get; set; }
    }
}
