using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FinanceMVC.Models;
using FinanceMVC.Models.Validations;

namespace FinanceMVC.ViewModel
{
    public class CompanyTarjetaCreditoFormViewModel
    {

        public CompanyTarjetaCreditoFormViewModel()
        {
            CompanyTarjetaCreditoId = 0;
            Productos = new HashSet<Productos>();
        }

        public int? CompanyTarjetaCreditoId { get; set; }

        [Required(ErrorMessage = "Debe escribir la compañia ")]
        [StringLength(200)]
        [Display(Name = "Nombre de la compañia")]
        public string NombreCompany { get; set; }

        [ValidarEstado]
        [Display(Name = "Seleccione el Estado")]
        [Required(ErrorMessage = "Debe Seleccionar el estado ")]
        public int EstadoId { get; set; }

        public virtual Estados Estados { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }

        public IEnumerable<Estados> ListadoEstados { get; set; }

        public string Titulo
        {
            get
            {
                return CompanyTarjetaCreditoId != 0 ? "Editando Compañia" : "Nueva Compañia";
            }
        }

        public CompanyTarjetaCreditoFormViewModel(CompanyTarjetaCreditos companyTarjeta)
        {
            CompanyTarjetaCreditoId = companyTarjeta.CompanyTarjetaCreditoId;
            NombreCompany = companyTarjeta.NombreCompany;
            EstadoId = companyTarjeta.EstadoId;
            
        }


    }
}