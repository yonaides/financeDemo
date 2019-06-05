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
              new { clienteId = src.ClienteId })));

            CreateMap<ServicioEntity, Servicio>()
                .ForMember(dest => dest.ServicioId, opt => opt.MapFrom(src => src.ServicioId))
                .ForMember(dest => dest.NombreServicio, opt => opt.MapFrom(src => src.NombreServicio))
                .ForMember(dest => dest.PrecioServicio, opt => opt.MapFrom(src => src.PrecioServicio))
                .ForMember(dest => dest.ServicioMetaData, opt => opt.MapFrom(src => 
                FormMetadata.FromModel(
                    new ServicioForm(), Link.ToForm(
                    nameof(Controllers.ServicioController.CreateServicio),
                            new { servicioId = src.ServicioId },
                            Link.PostMethod,
                            Form.CreateRelation
                    ))))

                .ForMember(dest => dest.DetalleServicio, opt => opt.MapFrom(src => src.DetalleServiciosEntity))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.ServicioController.GetServicioById),
              new { servicioId = src.ServicioId })));

            CreateMap<DetalleServicioEntity, DetalleServicio>()
                .ForMember(dest => dest.DetalleServicioId, opt => opt.MapFrom(src => src.DetalleServicioId))
                .ForMember(dest => dest.ServicioEntityFK, opt => opt.MapFrom(src => src.ServicioEntityFK))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.DetalleServicioController.GetDetalleServicioById),
              new { detalleServicioId = src.DetalleServicioId})));

       CreateMap<UserEntity, User>()
            .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
            Link.To(nameof(Controllers.UsersController.GetUserById),
            new { userId = src.Id })));

        }

    }
}
