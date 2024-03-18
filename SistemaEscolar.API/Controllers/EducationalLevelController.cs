using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Application.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalLevelController : ControllerBase
    {
        private readonly IEducationalLevelApplication _educationalLevel;

        public EducationalLevelController(IEducationalLevelApplication educationalLevel)
        {
            _educationalLevel = educationalLevel;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _educationalLevel.GetAllEducationalLevels();
            return Ok(response);
        }

        [HttpGet("{educationalLevelId:int}")]
        public async Task<IActionResult> GetEducationalLevelById(int educationalLevelId)
        {
            var response = await _educationalLevel.GetEducationalLevelById(educationalLevelId);
            return Ok(response);
        }
    }
}
