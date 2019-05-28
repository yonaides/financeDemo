using AutoMapper;
using CotizacionesPersonalesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace CotizacionesPersonalesApi.Services
{
    public class DefaultServicioService : IServicioService
    {
        private readonly CotizacionesPersonalesApiDbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultServicioService(
            CotizacionesPersonalesApiDbContext context,
            IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public Task<int> CreateServicioAsync(
            int id,
            string NombreServicio,
            float PrecioServicio)
        {
            // TODO: Save the new booking to the database
            throw new NotImplementedException();
        }

        public async Task<Servicio> GetServicioAsync(int servicioId)
        {
            var entity = await _context.Servicios.Include(d => d.DetalleServiciosId)
                .SingleOrDefaultAsync(b => b.ServicioId == servicioId);

            if (entity == null) return null;

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Servicio>(entity);

        }

        public async Task<IEnumerable<Servicio>> GetServicioAsync()
        {
            var query = _context.Servicios.Include(de => de.DetalleServiciosId).ProjectTo<Servicio>(_mappingConfiguration);
            return await query.ToArrayAsync();
        }
    }
}
