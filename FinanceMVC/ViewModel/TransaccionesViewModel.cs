using FinanceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceMVC.ViewModel
{
    public class TransaccionesViewModel
    {
        public int TransaccionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaTransaccion { get; set; }

        public double Monto { get; set; }

        public string Descripcion { get; set; }

        public int TipoTransaccionId { get; set; }

        public int EstadoTarjetaId { get; set; }

        public IEnumerable<EstadoTarjetas> ListadoDeEstadosTarjetas { get; set; }
        public IEnumerable<TipoTransacciones> ListadoDeTiposDeTransacciones { get; set; }

        public string Titulo
        {
            get
            {
                return TransaccionId != 0 ? "Editando Transacciones" : "Nueva Transaccion";
            }
        }

        public TransaccionesViewModel(Transacciones transaccion)
        {
            TransaccionId = transaccion.TransaccionId;
            Descripcion = transaccion.Descripcion;
            FechaCreacion = transaccion.FechaCreacion;
            FechaTransaccion = transaccion.FechaTransaccion;
            Monto = transaccion.Monto;
            TipoTransaccionId = transaccion.TipoTransaccionId;
            EstadoTarjetaId = transaccion.EstadoTarjetaId;
            
        }


    }
}