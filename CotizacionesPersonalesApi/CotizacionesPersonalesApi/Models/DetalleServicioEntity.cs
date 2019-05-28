using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class DetalleServicioEntity
    {
        public int Id { get; set; }
        public ServicioEntity ServicioId { get; set; }
        public string Descripcion { get; set; }
    }
}
