using AutoMapper;
using SistemaEscolar.Application.Dtos.EducationalLevel.Response;
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Application.Mappers
{
    public class EducationalLevelMappingsProfile : Profile
    {
        public EducationalLevelMappingsProfile()
        {
            CreateMap<EducationalLevel, EducationalLevelResponseDto>()              
              .ReverseMap();
        }
    }
}
