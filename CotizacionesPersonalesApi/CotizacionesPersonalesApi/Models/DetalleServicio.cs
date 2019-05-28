using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class DetalleServicio: Resource
    {
        public int DetalleServicioId { get; set; }
        public int ServicioEntityFK { get; set; }
        public string Descripcion { get; set; }

    }
}
