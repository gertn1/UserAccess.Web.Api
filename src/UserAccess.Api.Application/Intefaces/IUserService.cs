
using UserAccess.Api.Application.Dtos;
using UserAccess.Api.Application.Responses;
using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Services.IServiceBase;

namespace UserAccess.Api.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User, UserCreationDto, UserEditDto, int>
    {
        
    }
}
