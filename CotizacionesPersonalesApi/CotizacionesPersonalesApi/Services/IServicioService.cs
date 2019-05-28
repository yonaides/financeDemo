using CotizacionesPersonalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Services
{
    public interface IServicioService
    {
        Task<Servicio> GetServicioAsync(int servicioId);

        Task<Servicio> CreateServicioAsync(
            int servicioId,
            string NombreServicio ,
            float PrecioServicio );
    }

}
