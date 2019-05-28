using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Services;
using CotizacionesPersonalesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet(Name = nameof(GetAllServicios))]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Collection<Servicio>>> GetAllServicios()
        {
            var servicio = await _servicioService.GetServicioAsync();
            var collections = new Collection<Servicio>
            {
                Self = Link.ToCollection(nameof(GetAllServicios)),
                Value = servicio.ToArray()

            };
            return collections;

        }


        //Get /servicio/{servicioId}
        [HttpGet("{servicioId}", Name = nameof(GetServicioById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Servicio>> GetServicioById(int servicioId)
        {
            var servicio = await _servicioService.GetServicioAsync(servicioId);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;

        }


    }
}