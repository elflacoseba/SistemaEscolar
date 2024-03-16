using SistemaEscolar.Application.Commons.Base;
using SistemaEscolar.Application.Dtos.Request;
using SistemaEscolar.Application.Dtos.Response;

namespace SistemaEscolar.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<IEnumerable<UserResponseDto>>> GetAllUsers();
        Task<BaseResponse<UserResponseDto>> GetUserById(int userId);
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
        Task<BaseResponse<bool>> EditUser(int userId, UserRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteUser(int userId);
    }
}
