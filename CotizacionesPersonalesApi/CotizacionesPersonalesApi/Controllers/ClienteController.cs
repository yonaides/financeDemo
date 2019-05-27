using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;
using Microsoft.EntityFrameworkCore;
using CotizacionesPersonalesApi.Services;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //private readonly CotizacionesPersonalesApiDbContext _context;
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet(Name = nameof(GetClientes))]
        public IActionResult GetClientes()
        {
            throw new NotImplementedException();
        }

        //Get /cliente/{clienteId}
        [HttpGet("{clienteId}", Name = nameof(GetClienteById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Cliente>> GetClienteById(int clienteId)
        {
            var cliente = await _clienteService.GetClienteAsync(clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;

        }

    }
}
