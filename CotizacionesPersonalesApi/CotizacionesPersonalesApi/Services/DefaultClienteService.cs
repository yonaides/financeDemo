﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CotizacionesPersonalesApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace CotizacionesPersonalesApi.Services
{
    public class DefaultClienteService : IClienteService
    {
        private readonly CotizacionesPersonalesApiDbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;


        public DefaultClienteService(
            CotizacionesPersonalesApiDbContext context,
            IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task DeleteClienteAsync(int clienteId)
        {
            var cliente = await _context.Clientes.SingleOrDefaultAsync(b => b.ClienteId == clienteId);

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

        }

        public async Task<Cliente> GetClienteAsync(int clienteId)
        {
            var entity = await _context.Clientes
                .SingleOrDefaultAsync(x => x.ClienteId == clienteId);

            if (entity == null)
            {
                return null;
            }
            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Cliente>(entity);
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            var query = _context.Clientes.ProjectTo<Cliente>(_mappingConfiguration);
            return await query.ToArrayAsync();

        }
    }
}
