using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Services;
using CotizacionesPersonalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CotizacionesPersonalesApi.AutoMapper;

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
        [ResponseCache(Duration = 30,
            VaryByQueryKeys = new[] { "offset", "limit", "orderBy", "search" })]
        public async Task<ActionResult<Collection<Servicio>>> GetAllServicios( [FromQuery] PagingOptions pagingOptions, 
                [FromQuery] SortOptions<Servicio, ServicioEntity> sortOptions, 
                [FromQuery] SearchOptions<Servicio, ServicioEntity> searchOptions)
        {

            await Task.Delay(3000); // utilizar en caso de procesos que tomen mucho tiempo

            pagingOptions.Offset = pagingOptions.Offset ?? _defaulPaginPaginOption.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaulPaginPaginOption.Limit;

            /*if (pagingOptions.Limit == null) pagingOptions.Limit = 100;
            if (pagingOptions.Offset == null) pagingOptions.Offset = 0;*/

            var servicio = await _servicioService.GetServicioAsync(pagingOptions, sortOptions, searchOptions);
            var collections = PagedCollection<Servicio>.Create<ServicioResponse>(
                Link.ToCollection(nameof(GetAllServicios)),
                servicio.Items.ToArray(),
                servicio.TotalSize,
                pagingOptions
                );
            

            collections.ServicioQuery = FormMetadata.FromResource<Servicio>(
                Link.ToForm(
                    nameof(GetAllServicios),
                    null,
                    Link.GetMethod,
                    Form.QueryRelation));


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

        // TODO authentication!
        // POST /servicio/crear
        [HttpPost("crear", Name = nameof(CreateServicio))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<ActionResult> CreateServicio([FromBody] ServicioForm servicioForm)
        {
            
            var servicioId = await _servicioService.CreateServicioAsync(
                servicioForm.NombreServicio, servicioForm.PrecioServicio);

            return Created(
                Url.Link(nameof(ServicioController.GetServicioById),new { servicioId }), null);

            /*
            return Created(
                Url.Link(nameof(BookingsController.GetBookingById),
                new { bookingId }),
                null);*/
        }
    }
 }
