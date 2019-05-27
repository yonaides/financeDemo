using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;

namespace CotizacionesPersonalesApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteEntity, Cliente>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreCliente));
            //TODO url.Link
        }


    }
}
