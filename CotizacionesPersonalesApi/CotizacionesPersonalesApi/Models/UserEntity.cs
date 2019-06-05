using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
}
