using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.Dtos
{
    public class EstadoTarjetasDto
    {
        
        public EstadoTarjetasDto()
        {
            TransaccionesDto = new HashSet<TransaccionesDto>();
        }

        public int EstadoTarjetaId { get; set; }

        public DateTime? FechaEstado { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public double BalancePendiente { get; set; }

        public int ProductosId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public ProductosDto ProductosDto { get; set; }

        public ICollection<TransaccionesDto> TransaccionesDto { get; set; }

    }
}