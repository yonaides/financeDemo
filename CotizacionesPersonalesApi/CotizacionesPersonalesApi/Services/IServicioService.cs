using CotizacionesPersonalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Services
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicio>> GetServicioAsync();
        
        Task<Servicio> GetServicioAsync(int servicioId);

        Task<int> CreateServicioAsync(
            int servicioId,
            string nombreServicio ,
            float precioServicio );
    }

}
