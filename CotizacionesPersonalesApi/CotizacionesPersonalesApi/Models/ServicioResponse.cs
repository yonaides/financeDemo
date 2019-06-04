using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class ServicioResponse : PagedCollection<Servicio>
    {
        public Form ServicioQuery { get; set; }
    }
}
