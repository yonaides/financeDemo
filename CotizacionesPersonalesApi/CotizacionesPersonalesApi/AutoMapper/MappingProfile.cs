using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotizacionesPersonalesApi.Models;
using CotizacionesPersonalesApi.Controllers;

namespace CotizacionesPersonalesApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteEntity, Cliente>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreCliente))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.DireccionCliente))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.TelefonoCliente))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailCliente))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.ClienteController.GetClienteById),
              new { clienteId = src.Id })));


            CreateMap<ServicioEntity, Servicio>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DetalleServiciosId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreServicio))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.PrecioServicio))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.ServicioController.GetServicioById),
              new { servicioId = src.ServicioId })));



            CreateMap<DetalleServicioEntity, DetalleServicio>()
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.DetalleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ServicioId, opt => opt.MapFrom(src => src.ServicioId))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.ClienteController.GetClienteById),
              new { clienteId = src.Id })));




        }


    }
}
