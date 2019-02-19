using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.Dtos
{
    public class TipoTransaccionesDto
    {
        
        public TipoTransaccionesDto()
        {
            Transacciones = new HashSet<TransaccionesDto>();
        }

        public int TipoTransaccionId { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<TransaccionesDto> Transacciones { get; set; }

    }
}