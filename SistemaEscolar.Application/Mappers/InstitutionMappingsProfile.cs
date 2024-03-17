using AutoMapper;
using SistemaEscolar.Application.Dtos.Institution.Request;
using SistemaEscolar.Application.Dtos.Institution.Response;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Application.Mappers
{
    public class InstitutionMappingsProfile : Profile
    {
        public InstitutionMappingsProfile()
        {
            CreateMap<Institution, InstitutionResponseDto>()
               .ForMember(x => x.StateUser, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
               .ReverseMap();

            CreateMap<InstitutionRequestDto, Institution>();            
        }
    }
}
