using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class ServicioEntity
    {
        public int ServicioId { get; set; }
        public string NombreServicio { get; set; }
        public float PrecioServicio { get; set; }
    }
}
