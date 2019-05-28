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
    public class DefaultDetalleServicioService : IDetalleServicioService
    {
        private readonly CotizacionesPersonalesApiDbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultDetalleServicioService(
            CotizacionesPersonalesApiDbContext context,
            IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public Task<int> CreateDetalleServicioAsync(
            int detalleServicioId,
            int servicioID,
            string descripcionServicio)
        {
            // TODO: Save the new booking to the database
            throw new NotImplementedException();
        }


        public async Task<DetalleServicio> GetDetalleServicioAsync(int detalleServicioId)
        {
            var entity = await _context.DetalleServicios.SingleOrDefaultAsync(b => b.DetalleServicioId == detalleServicioId);

            if (entity == null) return null;

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<DetalleServicio>(entity);

        }

        public async Task<IEnumerable<DetalleServicio>> GetDetalleServicioAsync()
        {
            var query = _context
                .DetalleServicios
                .ProjectTo<DetalleServicio>(_mappingConfiguration);
            return await query.ToArrayAsync();
        }

    }
}
