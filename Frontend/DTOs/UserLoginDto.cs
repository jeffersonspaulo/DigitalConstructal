using System.Text.Json.Serialization;

namespace DigitalConstructalWeb.DTOs
{
    public class UserLoginDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string Password { get; set; }
    }
}
