using SistemaEscolar.Application.Commons.Base;
using SistemaEscolar.Application.Dtos.Institution.Request;
using SistemaEscolar.Application.Dtos.Institution.Response;

namespace SistemaEscolar.Application.Interfaces
{
    public interface IInstitutionApplication
    {
        Task<BaseResponse<IEnumerable<InstitutionResponseDto>>> GetAllInstitutions();
        Task<BaseResponse<InstitutionResponseDto>> GetInstitutionById(int institutionId);
        Task<BaseResponse<bool>> CreateInstitution(InstitutionRequestDto requestDto);
        Task<BaseResponse<bool>> EditInstitution(int institutionId, InstitutionRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteInstitution(int institutionId);
    }
}
