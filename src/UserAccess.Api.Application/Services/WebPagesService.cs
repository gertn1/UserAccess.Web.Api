using UserAccess.Api.Application.Dtos;
using UserAccess.Api.Application.Responses;
using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Repositories;
using UserAccess.Api.Domain.Interfaces.Services;

namespace UserAccess.Api.Application.Services
{
    public class WebPageService : IWebPageService
    {
        private readonly IWebPageRepository _webPageRepository;

        public WebPageService(IWebPageRepository webPageRepository)
        {
            _webPageRepository = webPageRepository;
        }

        public async Task<ResponseModel<List<WebPage>>> ListAsync()
        {
            var response = new ResponseModel<List<WebPage>>();
            try
            {
                var pages = await _webPageRepository.ListAllAsync();
                response.Dados = pages;
                response.Mensagem = "Pages retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<WebPage?>> GetByIdAsync(int id)
        {
            var response = new ResponseModel<WebPage?>();
            try
            {
                var page = await _webPageRepository.GetByIdAsync(id);
                if (page == null)
                {
                    response.Status = false;
                    response.Mensagem = "Page not found.";
                    return response;
                }
                response.Dados = page;
                response.Mensagem = "Page retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<WebPage?>> CreateAsync(WebPageCreateDto WebPagedto)
        {
            var response = new ResponseModel<WebPage?>();
            try
            {
                var page = new WebPage
                {
                    Title = WebPagedto.Title,
                    Content = WebPagedto.Content,
                    Url = WebPagedto.Url

                };

                var createdPage = await _webPageRepository.CreateAsync(page);
                response.Dados = createdPage;
                response.Mensagem = "Page created successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<WebPage>> UpdateAsync(WebPageEditDto dto)
        {
            var response = new ResponseModel<WebPage>();
            try
            {
                var page = await _webPageRepository.GetByIdAsync(dto.Id);
                if (page == null)
                {
                    response.Status = false;
                    response.Mensagem = "Page not found.";
                    return response;
                }

                page.Title = dto.Title;
                page.Content = dto.Content;
              

                var updatedPage = await _webPageRepository.UpdateAsync(page);
                response.Dados = updatedPage;
                response.Mensagem = "Page updated successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            var response = new ResponseModel<bool>();
            try
            {
                var deleted = await _webPageRepository.DeleteAsync(id);
                if (!deleted)
                {
                    response.Status = false;
                    response.Mensagem = "Page not found.";
                    return response;
                }
                response.Dados = true;
                response.Mensagem = "Page deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }
    }
}
