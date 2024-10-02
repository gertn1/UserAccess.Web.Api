using UserAccess.Api.Application.Dtos.Base;

namespace UserAccess.Api.Application.Dtos
{
    public class WebPageEditDto : DtoBase
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}//
