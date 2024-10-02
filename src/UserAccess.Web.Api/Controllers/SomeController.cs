// SomeController.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace UserAccess.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("current-user")]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
          
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (userId == null)
            {
                return Unauthorized("User is not logged in.");
            }

            return Ok(new
            {
               
                Name = userName,
                Role = userRole
            });
        }
    }
}
