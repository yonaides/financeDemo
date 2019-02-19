using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.Dtos
{
    public class CompanyTarjetaCreditosDto
    {
        
        public CompanyTarjetaCreditosDto()
        {
            ProductosDto = new HashSet<ProductosDto>();
        }

        
        public int CompanyTarjetaCreditoId { get; set; }

        public string NombreCompany { get; set; }

        public int EstadoId { get; set; }

        public virtual EstadosDto Estados { get; set; }

        public virtual ICollection<ProductosDto> ProductosDto { get; set; }
    }
}