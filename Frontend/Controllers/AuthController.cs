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

  public IActionResult ForgotPassword() => View();
  public IActionResult Login() => View();
  public IActionResult Register() => View();

  public async Task<IActionResult> RegisterSubmit(string name, string email, string password)
  {
    try
    {
      if (await _userService.UserExistsAsync(email))
        return BadRequest("The Email is already in use.");

      var form = new UserLoginDto{ Name = name, Email = email, Password = password };

      await _userService.Insert(form);

      await _userService.Authenticate(email, HttpContext);

      return RedirectToAction("Index", "Dashboards");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, ex.Message);
      return RedirectToAction("MiscUnderMaintenance", "Pages");
      //return BadRequest(new { ErrorMessage = "An error occurred while registering the user." });
    }
  }

  [HttpPost]
  public async Task<IActionResult> LoginSubmit(string email, string password)
  {
    try
    {
      var user = await _userService.GetByEmail(email);

      if (user == null || !IsValidUser(password, user))
      {
        return Unauthorized("Invalid username or password.");
      }

      await _userService.Authenticate(user.Email, HttpContext);

      return RedirectToAction("Index", "Dashboards");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, ex.Message);
      return RedirectToAction("MiscUnderMaintenance", "Pages");
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
