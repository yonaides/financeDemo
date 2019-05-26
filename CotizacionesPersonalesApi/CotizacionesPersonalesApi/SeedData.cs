using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CotizacionesPersonalesApi
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<CotizacionesPersonalesApiDbContext>());
        }

        public static async Task AddTestData(CotizacionesPersonalesApiDbContext context)
        {
            if (context.Clientes.Any())
            {   //Already exist
                return;
            }

            context.Clientes.Add(new ClienteEntity
            {
                Id = 1,
                NombreCliente = "Yonaides Tavares",
                DireccionCliente = "En el apto",
                TelefonoCliente = "874-985-9654",
                EmailCliente = "yonaides@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                Id = 2,
                NombreCliente = "Yonaides Antonio",
                DireccionCliente = "En el apto",
                TelefonoCliente = "874-985-9654",
                EmailCliente = "yonaides@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                Id = 3,
                NombreCliente = "Yonaides ShulterBrondt",
                DireccionCliente = "En el apto",
                TelefonoCliente = "874-985-9654",
                EmailCliente = "yonaides@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                Id = 4,
                NombreCliente = "Julie Pichardo",
                DireccionCliente = "En el apto",
                TelefonoCliente = "874-985-9654",
                EmailCliente = "yonaides@gmail.com"
            });

            await context.SaveChangesAsync();

        }
    }
}
