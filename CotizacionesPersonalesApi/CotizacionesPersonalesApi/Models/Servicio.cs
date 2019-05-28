using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class Servicio : Resource
    {
        public int ServicioId { get; set; }
        [JsonIgnore]
        public virtual ICollection<DetalleServicio> DetalleServicio { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }

    }
}
