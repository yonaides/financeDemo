using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class DetalleServicio: Resource
    {
        public int DetalleId { get; set; }
        public ServicioEntity ServicioId { get; set; }
        public string Descripcion { get; set; }

    }
}
