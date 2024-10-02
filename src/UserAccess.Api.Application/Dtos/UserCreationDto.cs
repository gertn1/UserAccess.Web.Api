using UserAccess.Api.Application.Dtos.Base;
using UserAccess.Api.Domain.Enums;

namespace UserAccess.Api.Application.Dtos
{
    public class UserCreationDto 
    {
        
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleType RoleId { get; set; }
    }
}
