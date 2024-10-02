using System.Text.Json.Serialization;

namespace UserAccess.Api.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }
    }
}
