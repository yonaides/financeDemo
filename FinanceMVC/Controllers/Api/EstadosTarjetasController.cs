using AutoMapper;
using FinanceMVC.Dtos;
using FinanceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FinanceMVC.Controllers.Api
{
    public class EstadosTarjetasController : ApiController
    {
        private FinanceDbContext _context;

        public EstadosTarjetasController()
        {
            _context = new FinanceDbContext();
        }

        // Get EstadosTarjetas/1
        [HttpGet]
        [Route("api/estadostarjetas/productoid/{id}")]
        public IHttpActionResult GetEstadosTarjetas(int id)
        {
            var estadosTarjetas = _context.EstadoTarjetas
                .ToList()
                .Where(c => c.ProductosId == id)
                .Select(Mapper.Map<EstadoTarjetas, EstadoTarjetasDto>);

            if (estadosTarjetas == null)
            {
                return NotFound();
            }

            return Ok(estadosTarjetas);

        }


    }
}