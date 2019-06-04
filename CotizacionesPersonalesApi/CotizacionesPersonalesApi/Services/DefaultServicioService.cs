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

        public async Task<int> CreateServicioAsync(string nombre, int precio)
        {
            var newServicio = _context.Servicios.Add(new ServicioEntity
            {
                NombreServicio = nombre,
                PrecioServicio = precio
            });

            var createAt = await _context.SaveChangesAsync();
            if (createAt < 1) throw new InvalidOperationException("Datos no pudieron ser salvados");

            return newServicio.Entity.ServicioId;
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


        public async Task<PagedResults<Servicio>> GetServicioAsync(PagingOptions pagingOptions, SortOptions<Servicio, ServicioEntity> sortOptions, SearchOptions<Servicio, ServicioEntity> searchOptions)
        {

            IQueryable<ServicioEntity> query = _context.Servicios;
            query = searchOptions.Apply(query);
            query = sortOptions.Apply(query);

            var size = await query.CountAsync();
            //var query = _context.Servicios.ProjectTo<Servicio>(_mappingConfiguration);
            var filtro = await query
                             .Skip(pagingOptions.Offset.Value)
                            .Take(pagingOptions.Limit.Value)
                            .ProjectTo<Servicio>(_mappingConfiguration)
                            .ToArrayAsync();

            //var listado = await query.ToArrayAsync();
            //var listadoServicios = listado.ToList();

            /*var filtro = listadoServicios
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value);*/

            return new PagedResults<Servicio> { 
                Items = filtro,
                TotalSize = size
            };
        }
    }
}
