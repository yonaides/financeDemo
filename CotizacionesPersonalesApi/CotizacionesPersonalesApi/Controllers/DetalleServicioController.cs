using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotizacionesPersonalesApi.Services;
using CotizacionesPersonalesApi.Models;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DetalleServicioController : ControllerBase
    {
        private readonly IDetalleServicioService _detalleServiceService;

        public DetalleServicioController(IDetalleServicioService detalleServiceService)
        {
            _detalleServiceService = detalleServiceService;
        }

        [HttpGet(Name = nameof(GetAllDetalleServicios))]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Collection<DetalleServicio>>> GetAllDetalleServicios()
        {
            //throw new NotImplementedException();
            var detalleServicios = await _detalleServiceService.GetDetalleServicioAsync();
            var collections = new Collection<DetalleServicio>
            {
                Self = Link.ToCollection(nameof(GetAllDetalleServicios)),
                Value = detalleServicios.ToArray()

            };
            return collections;

        }

        //Get /detalleServicio/{detalleServicioId}
        [HttpGet("{detalleServicioId}", Name = nameof(GetDetalleServicioById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<DetalleServicio>> GetDetalleServicioById(int detalleServicioId)
        {
            var detalleServicio = await _detalleServiceService.GetDetalleServicioAsync(detalleServicioId);

            if (detalleServicio == null)
            {
                return NotFound();
            }

            return detalleServicio;

        }

    }
}