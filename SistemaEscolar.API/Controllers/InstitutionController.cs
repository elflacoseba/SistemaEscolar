using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Application.Dtos.Institution.Request;
using SistemaEscolar.Application.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionApplication _institutionApplication;

        public InstitutionController(IInstitutionApplication institutionApplication)
        {
            _institutionApplication = institutionApplication;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _institutionApplication.GetAllInstitutions();
            return Ok(response);
        }

        [HttpGet("{institutionId:int}")]
        public async Task<IActionResult> GetInstitutionById(int institutionId)
        {
            var response = await _institutionApplication.GetInstitutionById(institutionId);
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateInstitution([FromBody] InstitutionRequestDto requestDto)
        {
            var response = await _institutionApplication.CreateInstitution(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{institutionId:int}")]
        public async Task<IActionResult> EditInstitution(int institutionId, [FromBody] InstitutionRequestDto requestDto)
        {
            var response = await _institutionApplication.EditInstitution(institutionId, requestDto);
            return Ok(response);
        }
        
        [HttpDelete("Delete/{institutionId:int}")]
        public async Task<IActionResult> DeleteInstitution(int institutionId)
        {
            var response = await _institutionApplication.DeleteInstitution(institutionId);
            return Ok(response);
        }
    }
}
