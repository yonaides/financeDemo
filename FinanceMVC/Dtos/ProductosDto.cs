using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.Dtos
{
    public class ProductosDto
    {
        public ProductosDto()
        {
            EstadoTarjetas = new HashSet<EstadoTarjetasDto>();
        }

        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public int? DiaVencimiento { get; set; }

        public double LimiteCredito { get; set; }

        public double? LimiteCreditoDollar { get; set; }

        public string Numero { get; set; }

        public int UsuarioId { get; set; }

        public int CompaniaTarjetaCreditoId { get; set; }

        public int BancoId { get; set; }

        public BancosDto Bancos { get; set; }

        public CompanyTarjetaCreditosDto CompanyTarjetaCreditos { get; set; }

        public ICollection<EstadoTarjetasDto> EstadoTarjetas { get; set; }

    }
}