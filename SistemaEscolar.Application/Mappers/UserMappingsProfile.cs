using AutoMapper;
using SistemaEscolar.Application.Dtos.User.Request;
using SistemaEscolar.Application.Dtos.User.Response;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Application.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<User, UserResponseDto>()
               .ForMember(x => x.StateUser, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
               .ReverseMap();

            CreateMap<UserRequestDto, User>();

            CreateMap<TokenRequestDto, User>();
        }
    }
}
