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
                ClienteId = 1,
                NombreCliente = "Yonaides Tavares",
                DireccionCliente = "En el apto",
                TelefonoCliente = "874-985-9654",
                EmailCliente = "yonaides@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                ClienteId = 2,
                NombreCliente = "Yonaides Antonio",
                DireccionCliente = "en su casa",
                TelefonoCliente = "874-985-7777",
                EmailCliente = "shulterbrond@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                ClienteId = 3,
                NombreCliente = "Yonaides ShulterBrondt",
                DireccionCliente = "casa de la abuela",
                TelefonoCliente = "874-985-6666",
                EmailCliente = "antonio@gmail.com"
            });

            context.Clientes.Add(new ClienteEntity
            {
                ClienteId = 4,
                NombreCliente = "Julie Pichardo",
                DireccionCliente = "casa de su madre",
                TelefonoCliente = "874-985-9999",
                EmailCliente = "julie@gmail.com"
            });


            var servicio1 = context.Servicios.Add(new ServicioEntity
            {
                //ServicioId = 1,
                NombreServicio = "Creacion Logo comercial",
                PrecioServicio = 500,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 1,
                ServicioEntity = servicio1,
                ServicioEntityFK = servicio1.ServicioId,
                Descripcion = "descripcion logo comercial 1 "

            });

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 2,
                ServicioEntity = servicio1,
                ServicioEntityFK = servicio1.ServicioId,
                Descripcion = "descripcion logo comercial 1 "

            });

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 3,
                ServicioEntity = servicio1,
                ServicioEntityFK = servicio1.ServicioId,
                Descripcion = "descripcion logo comercial 1 "

            });

            var servicio2 = context.Servicios.Add(new ServicioEntity
            {
                //ServicioId = 2,
                NombreServicio = "Creacion Logo empresarial",
                PrecioServicio = 400,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 4,
                ServicioEntity = servicio2,
                ServicioEntityFK = servicio2.ServicioId,
                Descripcion = "descripcion Logo empresarial 2 "

            });

            var servicio3 = context.Servicios.Add(new ServicioEntity
            {
                //ServicioId = 3,
                NombreServicio = "Creacion Logo personal",
                PrecioServicio = 300,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 5,
                ServicioEntity = servicio3,
                ServicioEntityFK = servicio3.ServicioId,
                Descripcion = "descripcion Logo personal 3 "

            });

            var servicio4 = context.Servicios.Add(new ServicioEntity
            {
                //ServicioId = 4,
                NombreServicio = "Creacion Logo poloche delante",
                PrecioServicio = 33,

            }).Entity;


            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 6,
                ServicioEntity = servicio4,
                ServicioEntityFK = servicio4.ServicioId,
                Descripcion = "descripcion Logo poloche delante"

            });

            var servicio5 = context.Servicios.Add(new ServicioEntity
            {
                //ServicioId = 5,
                NombreServicio = "Creacion Logo poloche detras",
                PrecioServicio = 25,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 7,
                ServicioEntity = servicio5,
                ServicioEntityFK = servicio5.ServicioId,
                Descripcion = "descripcion Logo poloche detras"

            });


            var servicio6 = context.Servicios.Add(new ServicioEntity
            {
                //ServicioId = 6,
                NombreServicio = "Creacion Logo camisa",
                PrecioServicio = 50,

            }).Entity;

            context.DetalleServicios.Add(new DetalleServicioEntity
            {
                DetalleServicioId = 8,
                ServicioEntity = servicio6,
                ServicioEntityFK = servicio6.ServicioId,
                Descripcion = "descripcion Logo camisa"

            });

            await context.SaveChangesAsync();

        }
    }
}
