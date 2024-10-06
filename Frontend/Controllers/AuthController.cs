using Microsoft.AspNetCore.Mvc;
using DigitalConstructalWeb.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;
using BC = BCrypt.Net.BCrypt;

namespace DigitalConstructalWeb.Controllers;

public class AuthController : Controller
{
  private readonly ILogger<AuthController> _logger;
  private readonly IUserService _userService;

  public AuthController(ILogger<AuthController> logger, IUserService userService)
  {
    _logger = logger;
    _userService = userService;
  }

  public IActionResult ForgotPasswordBasic() => View();
  public IActionResult LoginBasic() => View();
  public IActionResult RegisterBasic() => View();

  public async Task<IActionResult> Register(UserLoginDto form)
  {
    try
    {
      if (await _userService.UserExistsAsync(form.Email))
        return BadRequest("The Email is already in use.");

      await _userService.Insert(form);

      return Ok();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, ex.Message);
      return BadRequest(new { ErrorMessage = "An error occurred while registering the user." });
    }
  }

  public async Task<IActionResult> Login([FromBody] UserAuthDto auth)
  {
    try
    {
      var user = await _userService.GetByEmail(auth.Email);

      if (user == null || !IsValidUser(auth.Password, user))
      {
        return Unauthorized("Invalid username or password.");
      }

      var token = GenerateToken(auth.Email);

      return Ok(new { token });
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, ex.Message);
      return BadRequest(new { ErrorMessage = "An error occurred while logging the user." });
    }
  }

  private bool IsValidUser(string password, UserLogin user)
  {
    var isGoogle = !string.IsNullOrEmpty(user.GoogleId);

    return isGoogle || BC.Verify(password, user.Password);
  }

  private string GenerateToken(string username)
  {
    var key = "Your_Super_Secret_Key_Here_With_Sufficient_Length";

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
                new Claim(ClaimTypes.Name, username)
            };

    var token = new JwtSecurityToken(
        issuer: "https://localhost:7236",
        audience: "https://localhost:7236",
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
