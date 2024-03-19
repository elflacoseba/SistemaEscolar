using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaEscolar.Application.Commons.Base;
using SistemaEscolar.Application.Dtos.User.Request;
using SistemaEscolar.Application.Dtos.User.Response;
using SistemaEscolar.Application.Interfaces;
using SistemaEscolar.Application.Validators;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;
using SistemaEscolar.Utilities.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace SistemaEscolar.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserValidator _validationRules;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, UserValidator validationRules, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
            _configuration = configuration;
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
            user.PasswordHash = BC.HashPassword(requestDto.Password);

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

        public Task<BaseResponse<UserResponseDto>> GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }
        
        public async Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<string>();
            var userAccount = await _unitOfWork.Users.AccountByUserName(requestDto.UserName!);

            if (userAccount is not null)
            {
                if (BC.Verify(requestDto.Password, userAccount.PasswordHash))
                {
                    response.IsSuccess = true;
                    response.Data = GenerateToken(userAccount);
                    response.Message = ReplyMessage.MESSAGE_TOKEN;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
                }
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Email!),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.UserName!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Email!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"]!)),
                notBefore: DateTime.UtcNow,
                signingCredentials: credential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
