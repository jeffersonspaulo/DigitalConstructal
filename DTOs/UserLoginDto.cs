﻿using System.Text.Json.Serialization;

namespace DigitalConstructal.DTOs
{
    public class UserLoginDto
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("google")]
        public string GoogleId { get; set; }

        public string Role { get; set; }
    }
}
