using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.Dtos
{
    public class EstadosDto
    {
        
        public EstadosDto()
        {
            CompanyTarjetaCreditosDto = new HashSet<CompanyTarjetaCreditosDto>();
        }


        public int EstadoId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<CompanyTarjetaCreditosDto> CompanyTarjetaCreditosDto { get; set; }


    }

}