using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.Dtos
{
    public class TransaccionesEstadosTarjetasDto
    {
        public int EstadoTarjetaId { get; set; }
        public List<TransaccionesDto> Transacciones { get; set; }
    }
}