using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ClienteInfo _clienteInfo;

        public InfoController(IOptions<ClienteInfo> clienteInfoWrapper)
        {
            _clienteInfo = clienteInfoWrapper.Value;
        }

        [HttpGet(Name = nameof(GetInfo)) ]
        [ProducesResponseType(200)]
        public ActionResult<ClienteInfo> GetInfo()
        {
            _clienteInfo.Href = Url.Link(nameof(GetInfo), null);
            return _clienteInfo;
        }
    }
}