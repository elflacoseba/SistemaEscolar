using AutoMapper;
using SistemaEscolar.Application.Commons.Base;
using SistemaEscolar.Application.Dtos.Request;
using SistemaEscolar.Application.Dtos.Response;
using SistemaEscolar.Application.Interfaces;
using SistemaEscolar.Application.Validators;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Commons.Bases.Request;
using SistemaEscolar.Infrastructure.Commons.Bases.Response;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserValidator _validationRules;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, UserValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<IEnumerable<UserResponseDto>>> GetAllUsers()
        {
            var response = new BaseResponse<IEnumerable<UserResponseDto>>();
            var users = await _unitOfWork.Users.GetAllAsync();

            if (users != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<UserResponseDto>>(users);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<UserResponseDto>> GetUserById(int userId)
        {
            var response = new BaseResponse<UserResponseDto>();
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<UserResponseDto>(user);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;

                return response;
            }

            var user = _mapper.Map<User>(requestDto); 

            response.Data = await _unitOfWork.Users.AddAsync(user);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditUser(int userId, UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var userEdit = await GetUserById(userId);

            if (userEdit == null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var user = _mapper.Map<User>(requestDto);
            user.Id = userId;
            response.Data = await _unitOfWork.Users.UpdateAsync(user);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteUser(int userId)
        {
            var response = new BaseResponse<bool>();
            var userDelete = await GetUserById(userId);

            if (userDelete.Data == null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }
    
            response.Data = await _unitOfWork.Users.RemoveAsync(userId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
