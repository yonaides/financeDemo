using CotizacionesPersonalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Services
{
    public interface IServicioService
    {
        //Task<PagedResults<Servicio>> GetServicioAsync();

        Task<PagedResults<Servicio>> GetServicioAsync(PagingOptions pagingOptions,
            SortOptions<Servicio, ServicioEntity> sortOptions,
            SearchOptions<Servicio, ServicioEntity> searchOptions);
        
        Task<Servicio> GetServicioAsync(int servicioId);

        Task<int> CreateServicioAsync(
            int servicioId,
            string nombreServicio ,
            int precioServicio );
    }

}
