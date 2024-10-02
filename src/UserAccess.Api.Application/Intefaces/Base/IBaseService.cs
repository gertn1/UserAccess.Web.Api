using UserAccess.Api.Application.Responses;

namespace UserAccess.Api.Domain.Interfaces.Services.IServiceBase
{
    public interface IBaseService<T, TCreateDto, TUpdateDto, TKey>
    {

        Task<ResponseModel<List<T>>> ListAsync();
        Task<ResponseModel<T?>> GetByIdAsync(TKey id);
        Task<ResponseModel<T>> CreateAsync(TCreateDto dto);
        Task<ResponseModel<T?>> UpdateAsync(TUpdateDto dto);
        Task<ResponseModel<bool>> DeleteAsync(TKey id);
    }
}
