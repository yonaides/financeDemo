using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Services;
using CotizacionesPersonalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;
        private readonly PagingOptions _defaulPaginPaginOption;

        public ServicioController(IServicioService servicioService, IOptions<PagingOptions> defaultPageOptionWrapper )
        {
            _servicioService = servicioService;
            _defaulPaginPaginOption = defaultPageOptionWrapper.Value ;
        }

        [HttpGet(Name = nameof(GetAllServicios))]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]        
        public async Task<ActionResult<Collection<Servicio>>> GetAllServicios( [FromQuery] PagingOptions pagingOptions = null )
        {
            //if (!ModelState.IsValid) return BadRequest;
            
            pagingOptions.Offset = pagingOptions.Offset ?? _defaulPaginPaginOption.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaulPaginPaginOption.Limit;

            /*if (pagingOptions.Limit == null) pagingOptions.Limit = 100;
            if (pagingOptions.Offset == null) pagingOptions.Offset = 0;*/

            var servicio = await _servicioService.GetServicioAsync(pagingOptions);
            var collections = PagedCollection<Servicio>.Create(
                Link.ToCollection(nameof(GetAllServicios)),
                servicio.Items.ToArray(),
                servicio.TotalSize,
                pagingOptions
                );

            /*{
                Self = Link.ToCollection(nameof(GetAllServicios)),
                Value = servicio.Items.ToArray(),
                Size = servicio.TotalSize,
                Offset = pagingOptions.Offset.Value,
                Limit = pagingOptions.Limit.Value

            };*/
            return collections;

        }


        /*[HttpGet(Name = nameof(GetAllServicios))]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Collection<Servicio>>> GetAllServicios()
        {
            var servicio = await _servicioService.GetServicioAsync();
            var collections = new PagedCollection<Servicio>
            {
                Self = Link.ToCollection(nameof(GetAllServicios)),
                Value = servicio.Items.ToArray(),
                Size = servicio.TotalSize,
                Offset = pagingOptions.Offset.Value,
                Limit = pagingOptions.Limit.Value

            };
            return collections;

        }*/

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