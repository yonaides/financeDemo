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


            var servicio1 = context.Servicios.Add(new ServicioEntity
            {
                ServicioId = 1,
                NombreServicio = "Creacion Logo comercial",
                PrecioServicio = 352f,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                Id = 1,
                ServicioId = servicio1,
                Descripcion = "descripcion logo comercial 1 "

            });

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                Id = 2,
                ServicioId = servicio1,
                Descripcion = "descripcion logo comercial 1 "

            });

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                Id = 3,
                ServicioId = servicio1,
                Descripcion = "descripcion logo comercial 1 "

            });

            var servicio2 = context.Servicios.Add(new ServicioEntity
            {
                ServicioId = 2,
                NombreServicio = "Creacion Logo empresarial",
                PrecioServicio = 352f,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                Id = 4,
                ServicioId = servicio2,
                Descripcion = "descripcion Logo empresarial 2 "

            });

            var servicio3 = context.Servicios.Add(new ServicioEntity
            {
                ServicioId = 3,
                NombreServicio = "Creacion Logo personal",
                PrecioServicio = 352f,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                Id = 4,
                ServicioId = servicio3,
                Descripcion = "descripcion Logo personal 3 "

            });


            await context.SaveChangesAsync();

        }
    }
}
