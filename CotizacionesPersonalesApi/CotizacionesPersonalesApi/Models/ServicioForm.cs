using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class ServicioForm
    {
        [Required]
        [Display(Name = "Servicio", Description = "Nombre del Servicio")]
        public string NombreServicio { get; set; }

        [Required]
        [Display(Name = "Precio", Description = "Precio")]
        public int PrecioServicio { get; set; }

    }
}
