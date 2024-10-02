
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAccess.Api.Application.Dtos;
using UserAccess.Api.Application.Responses;
using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Services;

namespace UserAccess.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("ListUser")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<List<User>>>> ListUsersAsync()
        {
            var response = await _userService.ListAsync();
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetUserById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<User>>> GetUserByIdAsync(int id)
        {
            var response = await _userService.GetByIdAsync(id);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<User>>> CreateUserAsync(UserCreationDto userDto)
        {
            var response = await _userService.CreateAsync(userDto);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            if (response.Dados?.Id == null)
            {
                return BadRequest("Unable to retrieve the ID of the newly created user.");
            }

           
            return Ok(response);
        }

        [HttpPut("EditUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<User>>> UpdateUserAsync(int id, UserEditDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest(new ResponseModel<User>
                {
                    Status = false,
                    Mensagem = "Mismatched user ID."
                });
            }

            var response = await _userService.UpdateAsync(userDto);
            if (!response.Status)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("RemoveUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<bool>>> DeleteUserAsync(int id)
        {
            var response = await _userService.DeleteAsync(id);
            if (!response.Status)
            {
                return NotFound(response);
            }

            return Ok(new ResponseModel<bool>
            {
                Status = true,
                Mensagem = "User deleted successfully.",
                Dados = true
            });
        }

    }
}

