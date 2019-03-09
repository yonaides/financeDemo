using FinanceMVC.Dtos;
using FinanceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FinanceMVC.Controllers.Api
{
    public class RegistrarTransaccionesController : ApiController
    {
        private FinanceDbContext _context;

        public RegistrarTransaccionesController()
        {
            _context = new FinanceDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewTransacction(TransaccionesEstadosTarjetasDto newTransacciones)
        {

            if (newTransacciones == null  )
            {
                return BadRequest("Transacciones estan vacias");
            }


            foreach (var transaccion in newTransacciones.Transacciones)
            {
                var estadoCuenta = _context.EstadoTarjetas.SingleOrDefault(c => c.EstadoTarjetaId == transaccion.EstadoTarjetaId);

                if (estadoCuenta == null )
                {
                    return BadRequest("Estado de cuenta no puede ser nulo");
                }

                var tipoTransaccion = _context.TipoTransacciones.Single(c => c.TipoTransaccionId == transaccion.TipoTransaccionId);

                if (tipoTransaccion == null)
                {
                    return BadRequest("Tipo Transacción no encontrado");
                }


                var newTransaccion = new Transacciones
                {
                    Descripcion = transaccion.Descripcion,
                    FechaCreacion = DateTime.Now,
                    FechaTransaccion = transaccion.FechaTransaccion,
                    Monto = transaccion.Monto,
                    EstadoTarjetaId = transaccion.EstadoTarjetaId,
                    TipoTransaccionId = transaccion.TipoTransaccionId

                };

                _context.Transacciones.Add(newTransaccion);

            }

            _context.SaveChanges();
            return Ok();

        }


        [HttpGet]
        public IHttpActionResult GetTransacction()
        {
            return Ok();
        }

    }
}