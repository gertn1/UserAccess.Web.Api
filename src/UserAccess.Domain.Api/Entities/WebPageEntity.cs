namespace UserAccess.Api.Domain.Entities
{
    public class WebPage
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
