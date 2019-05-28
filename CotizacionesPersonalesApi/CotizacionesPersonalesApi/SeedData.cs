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
                DireccionCliente = "en su casa",
                TelefonoCliente = "874-985-7777",
                EmailCliente = "shulterbrond@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                Id = 3,
                NombreCliente = "Yonaides ShulterBrondt",
                DireccionCliente = "casa de la abuela",
                TelefonoCliente = "874-985-6666",
                EmailCliente = "antonio@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                Id = 4,
                NombreCliente = "Julie Pichardo",
                DireccionCliente = "casa de su madre",
                TelefonoCliente = "874-985-9999",
                EmailCliente = "julie@gmail.com"
            });




            await context.SaveChangesAsync();

        }
    }
}
