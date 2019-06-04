using CotizacionesPersonalesApi.AutoMapper;
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
        [Sortable(Default = true)]
        [Searchable]
        public string NombreServicio { get; set; }

        [Sortable]
        [SearchableDecimal]
        public int PrecioServicio { get; set; }

        public Form ServicioMetaData { get; set; }

    }
}
