using CotizacionesPersonalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Services
{
    public interface IDetalleServicioService
    {
        Task<IEnumerable<DetalleServicio>> GetDetalleServicioAsync();
        
        Task<DetalleServicio> GetDetalleServicioAsync(int detalleServicioId);

        Task<int> CreateDetalleServicioAsync(
            int detalleServicioId,
            int servicioID,
            string descripcionServicio
             );
    }

}
