using AutoMapper;
using FinanceMVC.Dtos;
using FinanceMVC.Models;

namespace FinanceMVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            

            Mapper.CreateMap<Bancos, BancosDto>();
            Mapper.CreateMap<BancosDto, Bancos>();

            Mapper.CreateMap<Productos, ProductosDto>();
            Mapper.CreateMap<ProductosDto, Productos>();

            Mapper.CreateMap<CompanyTarjetaCreditos, CompanyTarjetaCreditosDto>();
            Mapper.CreateMap<CompanyTarjetaCreditosDto, CompanyTarjetaCreditos>();

            Mapper.CreateMap<Estados, EstadosDto>();
            Mapper.CreateMap<EstadosDto, Estados>();

            Mapper.CreateMap<EstadoTarjetas, EstadoTarjetasDto>();
            Mapper.CreateMap<EstadoTarjetasDto, EstadoTarjetas>();

            Mapper.CreateMap<TipoTransacciones, TipoTransaccionesDto>();
            Mapper.CreateMap<TipoTransaccionesDto, TipoTransacciones>();

            Mapper.CreateMap<Transacciones, TransaccionesDto>();
            Mapper.CreateMap<TransaccionesDto, Transacciones>();



        }

    }
}