using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class ClienteEntity
    {
        [Key]
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; } 
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string EmailCliente { get; set; }

    }
}
