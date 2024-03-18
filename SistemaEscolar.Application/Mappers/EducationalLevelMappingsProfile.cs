using AutoMapper;
using SistemaEscolar.Application.Dtos.Institution.Response;
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Application.Mappers
{
    public class EducationalLevelMappingsProfile : Profile
    {
        public EducationalLevelMappingsProfile()
        {
            CreateMap<Institution, InstitutionResponseDto>()              
              .ReverseMap();
        }
    }
}
