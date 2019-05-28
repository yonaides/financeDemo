using AutoMapper;
using CotizacionesPersonalesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Services
{
    public class DefaultServicioService : IServicioService
    {
        private readonly CotizacionesPersonalesApiDbContext _context;
        private readonly IMapper _mapper;

        public DefaultServicioService(
            CotizacionesPersonalesApiDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> CreateServicioAsync(
            int userId,
            string NombreServicio,
            float PrecioServicio)
        {
            // TODO: Save the new booking to the database
            throw new NotImplementedException();
        }

        public async Task<Servicio> GetServicioAsync(int servicioId)
        {
            var entity = await _context.Servicio
                .SingleOrDefaultAsync(b => b.Id == servicioId);

            if (entity == null) return null;

            return _mapper.Map<Servicio>(entity);
        }

    }
}
