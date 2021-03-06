﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CotizacionesPersonalesApi
{
    public class CotizacionesPersonalesApiDbContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public CotizacionesPersonalesApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<ServicioEntity> Servicios { get; set; }
        public DbSet<DetalleServicioEntity> DetalleServicios { get; set; }
        public DbSet<CotizacionEntity> Cotizaciones { get; set; }
        public DbSet<CotizacionDetalleEntity> CotizacionesDetalles { get; set; }

    }
}
