

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
    public class WebPageController : ControllerBase
    {
        private readonly IWebPageService _webPageService;

        public WebPageController(IWebPageService webPageService)
        {
            _webPageService = webPageService;
        }

        [HttpGet("PagesList")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<ResponseModel<List<WebPage>>>> ListPagesAsync()
        {
            var response = await _webPageService.ListAsync();
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetPageById/{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<ResponseModel<WebPage>>> GetPageByIdAsync(int id)
        {
            var response = await _webPageService.GetByIdAsync(id);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("CreatePage")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<WebPage>>> CreatePageAsync(WebPageCreateDto webPageDto)
        {
            var response = await _webPageService.CreateAsync(webPageDto);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            if (response.Dados?.Id == null)
            {
                return BadRequest("Unable to retrieve the ID of the newly created page.");
            }

            return Ok(response);
        }

        [HttpPut("EditPage/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<WebPage>>> UpdatePageAsync(int id, WebPageEditDto webPageDto)
        {
            if (id != webPageDto.Id)
            {
                return BadRequest(new ResponseModel<WebPage>
                {
                    Status = false,
                    Mensagem = "Mismatched page ID."
                });
            }

            var response = await _webPageService.UpdateAsync(webPageDto);
            if (!response.Status)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("RemovePage/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<bool>>> DeletePageAsync(int id)
        {
            var response = await _webPageService.DeleteAsync(id);
            if (!response.Status)
            {
                return NotFound(response);
            }

            return Ok(new ResponseModel<bool>
            {
                Status = true,
                Mensagem = "Page deleted successfully.",
               
            });
        }
    }
}
