using AutoMapper;
using SistemaEscolar.Application.Commons.Base;
using SistemaEscolar.Application.Dtos.EducationalLevel.Response;
using SistemaEscolar.Application.Interfaces;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Application.Services
{
    public class EducationalLevelApplication : IEducationalLevelApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;        

        public EducationalLevelApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task<BaseResponse<IEnumerable<EducationalLevelResponseDto>>> GetAllEducationalLevels()
        {
            var response = new BaseResponse<IEnumerable<EducationalLevelResponseDto>>();
            var educationalLevels = await _unitOfWork.EducationalLevels.GetAllAsync();

            if (educationalLevels != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<EducationalLevelResponseDto>>(educationalLevels);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<EducationalLevelResponseDto>> GetEducationalLevelById(int educationalLevelId)
        {
            var response = new BaseResponse<EducationalLevelResponseDto>();
            var educationalLevel = await _unitOfWork.EducationalLevels.GetByIdAsync(educationalLevelId);

            if (educationalLevel != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<EducationalLevelResponseDto>(educationalLevel);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

    }
}
