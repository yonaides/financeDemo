using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new RootResponse
            {
                Self = Link.To(nameof(GetRoot)),
                Clientes = Link.ToCollection(nameof(ClienteController.GetAllClientes)), 
                Info = Link.To(nameof(InfoController.GetInfo))
            };

            return Ok(response);

        }
    }
}
