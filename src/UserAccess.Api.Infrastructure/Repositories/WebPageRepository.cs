
using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Repositories;
using UserAccess.Api.Infrastructure.Data;

namespace UserAccess.Api.Infrastructure.Repositories
{
    public class WebPageRepository : RepositoryBase<WebPage, int>, IWebPageRepository
    {
        public WebPageRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
