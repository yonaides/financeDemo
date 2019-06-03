using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class ServicioEntity
    {
        [Key]
        public int ServicioId { get; set; }
        public virtual ICollection<DetalleServicioEntity> DetalleServiciosEntity { get; set; }
        public string NombreServicio { get; set; }
        public int PrecioServicio { get; set; }

    }
}
