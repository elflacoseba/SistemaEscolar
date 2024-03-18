using SistemaEscolar.Application.Commons.Base;
using SistemaEscolar.Application.Dtos.EducationalLevel.Response;

namespace SistemaEscolar.Application.Interfaces
{
    public interface IEducationalLevelApplication
    {
        Task<BaseResponse<IEnumerable<EducationalLevelResponseDto>>> GetAllEducationalLevels();
        Task<BaseResponse<EducationalLevelResponseDto>> GetEducationalLevelById(int educationalLevelId);
    }
}
