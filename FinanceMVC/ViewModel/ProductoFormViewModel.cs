using FinanceMVC.Models;
using FinanceMVC.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceMVC.ViewModel
{
    public class ProductoFormViewModel
    {
        
        public ProductoFormViewModel()
        {
            ProductoId = 0;
        }

        public int? ProductoId { get; set; }

        [Display(Name = "Nombre del producto")]
        [StringLength(200)]
        [Required(ErrorMessage = "Digite el nombre de nombre del producto")]
        public string Nombre { get; set; }

        [Display(Name = "Dia de Vencimiento")]
        public int? DiaVencimiento { get; set; }

        [Display(Name = "Limite Credito Pesos")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Required(ErrorMessage = "Digite el limite de credito en pesos")]
        public double LimiteCredito { get; set; }

        [Display(Name = "Limite Credito Dollars")]
        public double? LimiteCreditoDollar { get; set; }

        [StringLength(4)]
        [Display(Name = "Ultimo 4 digitos")]
        [Required(ErrorMessage = "Digite los 4 digitos de la tarjeta")]
        public string Numero { get; set; }

        [ValidarCompanyTarjetaCredito]
        [Required(ErrorMessage = "Seleccione la Compañia de Tarjeta de Credito")]
        public int CompaniaTarjetaCreditoId { get; set; }

        [ValidarBanco]
        [Required(ErrorMessage = "Seleccione el Banco")]
        public int BancoId { get; set; }

        public Bancos Banco { get; set; }

        public CompanyTarjetaCreditos CompanyTarjetaCredito { get; set; }

        public IEnumerable<Bancos> ListadoBancos { get; set; }

        public IEnumerable<CompanyTarjetaCreditos> ListadoCompanyTarjetasCreditos { get; set; }

        public string Titulo
        {
            get
            {
                return ProductoId != 0 ? "Editando Producto" : "Nuevo Producto";
            }
        }

        public ProductoFormViewModel(Productos producto)
        {
            ProductoId = producto.ProductoId;
            Nombre = producto.Nombre;
            DiaVencimiento = producto.DiaVencimiento;
            LimiteCredito = producto.LimiteCredito;
            LimiteCreditoDollar = producto.LimiteCreditoDollar;
            Numero = producto.Numero;
            CompaniaTarjetaCreditoId = producto.CompaniaTarjetaCreditoId;
            BancoId = producto.BancoId;

        }

    }
}