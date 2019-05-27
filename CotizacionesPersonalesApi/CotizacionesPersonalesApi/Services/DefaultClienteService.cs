using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CotizacionesPersonalesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CotizacionesPersonalesApi.Services
{
    public class DefaultClienteService : IClienteService
    {
        private readonly CotizacionesPersonalesApiDbContext _context;
        private readonly IMapper _mapper;

        public DefaultClienteService(
            CotizacionesPersonalesApiDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cliente> GetClienteAsync(int clienteId)
        {
            var entity = await _context.Clientes
                .SingleOrDefaultAsync(x => x.Id == clienteId);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<Cliente>(entity);
        }
    }
}
