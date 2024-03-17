using AutoMapper;
using Microsoft.Extensions.Configuration;
using SistemaEscolar.Application.Commons.Base;
using SistemaEscolar.Application.Dtos.Institution.Request;
using SistemaEscolar.Application.Dtos.Institution.Response;
using SistemaEscolar.Application.Dtos.User.Response;
using SistemaEscolar.Application.Interfaces;
using SistemaEscolar.Application.Validators;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Application.Services
{
    public class InstitutionApplication : IInstitutionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly InstitutionValidator _validationRules;

        public InstitutionApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, InstitutionValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _validationRules = validationRules;
        }
        public async Task<BaseResponse<IEnumerable<InstitutionResponseDto>>> GetAllInstitutions()
        {
            var response = new BaseResponse<IEnumerable<InstitutionResponseDto>>();
            var institutions = await _unitOfWork.Institutions.GetAllAsync();

            if (institutions != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<InstitutionResponseDto>>(institutions);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<InstitutionResponseDto>> GetInstitutionById(int institutionId)
        {
            var response = new BaseResponse<InstitutionResponseDto>();
            var institution = await _unitOfWork.Institutions.GetByIdAsync(institutionId);

            if (institution != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<InstitutionResponseDto>(institution);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> CreateInstitution(InstitutionRequestDto requestDto)
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

            var institution = _mapper.Map<Institution>(requestDto);            

            response.Data = await _unitOfWork.Institutions.AddAsync(institution);

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

        public async Task<BaseResponse<bool>> EditInstitution(int institutionId, InstitutionRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var institutionEdit = await GetInstitutionById(institutionId);

            if (institutionEdit == null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var institution = _mapper.Map<Institution>(requestDto);
            institution.Id = institutionId;
            response.Data = await _unitOfWork.Institutions.UpdateAsync(institution);

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

        public async Task<BaseResponse<bool>> DeleteInstitution(int institutionId)
        {
            var response = new BaseResponse<bool>();
            var institutionDelete = await GetInstitutionById(institutionId);

            if (institutionDelete.Data == null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.Institutions.RemoveAsync(institutionId);

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
