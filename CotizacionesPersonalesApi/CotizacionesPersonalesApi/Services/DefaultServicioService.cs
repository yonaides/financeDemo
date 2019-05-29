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
            var entity = await _context.Servicios
                .SingleOrDefaultAsync(b => b.ServicioId == servicioId);

            if (entity == null) return null;

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Servicio>(entity);

        }

        /*public async Task<IEnumerable<Servicio>> GetServicioAsync()
        {
            var query = _context.Servicios.ProjectTo<Servicio>(_mappingConfiguration);
            return await query.ToArrayAsync();
        }*/


        public async Task<PagedResults<Servicio>> GetServicioAsync(PagingOptions pagingOptions)
        {
            var query = _context.Servicios.ProjectTo<Servicio>(_mappingConfiguration);
            var listado = await query.ToArrayAsync();
            var listadoServicios = listado.ToList();

            var filtro = listadoServicios
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value);

            return new PagedResults<Servicio> { 
                Items = filtro,
                TotalSize = listadoServicios.Count
             };
        }
    }
}
