using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        [HttpGet(Name = nameof(GetClientes))]
        public IActionResult GetClientes()
        {
            throw new NotImplementedException();

        }
    }
}
