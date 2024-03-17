using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Application.Dtos.User.Request;
using SistemaEscolar.Application.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost("Generate/Token")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequestDto requestDto)
        {
            var response = await _userApplication.GenerateToken(requestDto);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userApplication.GetAllUsers();
            return Ok(response);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var response = await _userApplication.GetUserById(userId);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestDto )
        {
            var response = await _userApplication.RegisterUser(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{userId:int}")]
        public async Task<IActionResult> EditUser(int userId, [FromBody] UserRequestDto requestDto)
        {
            var response = await _userApplication.EditUser(userId, requestDto);
            return Ok(response);
        }

        [HttpDelete("Delete/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await _userApplication.DeleteUser(userId);
            return Ok(response);
        }

    }

}
