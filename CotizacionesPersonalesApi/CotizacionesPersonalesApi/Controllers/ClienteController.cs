using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CotizacionesPersonalesApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly CotizacionesPersonalesApiDbContext _context;

        public ClienteController(CotizacionesPersonalesApiDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(GetClientes))]
        public IActionResult GetClientes()
        {
            throw new NotImplementedException();
        }

        //Get /cliente/{clienteId}
        [HttpGet("{clienteId}", Name = nameof(GetClienteById))]
        public async Task<ActionResult<Cliente>> GetClienteById(int clienteId)
        {
            var entity = await _context.Clientes.SingleOrDefaultAsync(x => x.Id == clienteId);

            if (entity == null)
            {
                return NotFound();
            }

            var resource = new Cliente
            {
                Href = Url.Link(nameof(GetClienteById), new { clienteId = entity.Id }),
                Direccion = entity.DireccionCliente,
                Nombre = entity.NombreCliente,
                Email = entity.EmailCliente,
                Telefono = entity.TelefonoCliente
            };

            return resource;

        }

    }
}
