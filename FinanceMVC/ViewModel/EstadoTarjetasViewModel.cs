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
            EstadoTarjetaId = 0;
        }

        public int? EstadoTarjetaId { get; set; }

        [Display(Name = "Fecha del Estado")]
        public DateTime? FechaEstado { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Balance Pendientes Pesos")]
        public double BalancePendiente { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Seleccione el producto")]
        public int ProductosId { get; set; }

        public virtual Productos Producto { get; set; }

        public IEnumerable<Productos> ListadoProductos { get; set; }


        public string Titulo
        {
            get
            {
                return EstadoTarjetaId != 0 ? "Editando Estado" : "Nuevo Estado";
            }
        }

        public EstadoTarjetasViewModel(EstadoTarjetas estadoTarjeta)
        {
            EstadoTarjetaId = estadoTarjeta.EstadoTarjetaId;
            BalancePendiente = estadoTarjeta.BalancePendiente;
            FechaCreacion = estadoTarjeta.FechaCreacion;
            FechaEstado = estadoTarjeta.FechaEstado;
            FechaVencimiento = estadoTarjeta.FechaVencimiento;
            ProductosId = estadoTarjeta.ProductosId;

        }

    }
}