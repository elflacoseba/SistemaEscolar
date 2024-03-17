using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Application.Dtos.Institution.Request;
using SistemaEscolar.Application.Dtos.User.Request;
using SistemaEscolar.Application.Interfaces;
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.API.Controllers
{
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

        [AllowAnonymous]
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
