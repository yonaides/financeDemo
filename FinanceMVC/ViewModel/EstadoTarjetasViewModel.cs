using FinanceMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceMVC.ViewModel
{
    public class EstadoTarjetasViewModel
    {
        
        public EstadoTarjetasViewModel()
        {   
        }

        public int EstadoTarjetaId { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Balance Pendientes Pesos")]
        public double BalancePendiente { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }

        public int ProductoId { get; set; }

        public Productos Producto { get; set; }

        [Required(ErrorMessage = "Seleccione el producto")]
        public IEnumerable<Productos> ListadoProductos { get; set; }
        
    }
}