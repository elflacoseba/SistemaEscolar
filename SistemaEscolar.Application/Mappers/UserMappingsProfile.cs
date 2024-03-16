using AutoMapper;
using SistemaEscolar.Application.Dtos.Request;
using SistemaEscolar.Application.Dtos.Response;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Commons.Bases.Response;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Application.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<User, UserResponseDto>()
                .ForMember(x => x.StateUser, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo" ))
                .ReverseMap();

            CreateMap<BaseEntityResponse<User>, BaseEntityResponse<UserResponseDto>>()
                .ReverseMap();

            CreateMap<UserRequestDto, User>();                                  
        }
    }
}
