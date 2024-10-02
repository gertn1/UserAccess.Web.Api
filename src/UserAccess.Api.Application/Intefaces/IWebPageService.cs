using UserAccess.Api.Application.Dtos;
using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Services.IServiceBase;

namespace UserAccess.Api.Domain.Interfaces.Services
{
    public interface IWebPageService : IBaseService<WebPage, WebPageCreateDto, WebPageEditDto, int >
    {
      
    }
}
