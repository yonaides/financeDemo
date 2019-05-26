using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;

namespace CotizacionesPersonalesApi
{
    public class CotizacionesPersonalesApiDbContext : DbContext
    {
        public CotizacionesPersonalesApiDbContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<ClienteEntity> Clientes { get; set; }
    }
}
