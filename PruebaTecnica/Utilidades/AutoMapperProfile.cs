using AutoMapper;
using PruebaTecnica.DTOs;
using PruebaTecnica.Entidades;

namespace PruebaTecnica.Utilidades
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<ClienteCreacionDTOs, Cliente>();
            CreateMap<Cliente,ClienteDTOs>();
            CreateMap<ClienteDTOs, Cliente>();

            CreateMap<DireccionesCreacionDTOs, Direcciones>();
            CreateMap<Direcciones, DireccionDTOs>();
        }
    }
}
