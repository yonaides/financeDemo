using CotizacionesPersonalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();

        Task<Cliente> GetClienteAsync(int clienteId);
    }
}
