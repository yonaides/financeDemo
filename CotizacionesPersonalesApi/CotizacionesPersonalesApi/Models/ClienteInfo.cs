using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class ClienteInfo : Resource
    {
        public long ID { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string EmailCliente { get; set; }

    }


}
