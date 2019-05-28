using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class DetalleServicioEntity
    {
        [Key]
        public int DetalleServicioId { get; set; }
        public ServicioEntity ServicioEntity { get; set; }
        public int ServicioEntityFK { get; set; }
        public string Descripcion { get; set; }

    }
}
