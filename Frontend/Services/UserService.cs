using AutoMapper;
using DigitalConstructalWeb.Data.Repository.Interfaces;
using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;
using DigitalConstructalWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using BC = BCrypt.Net.BCrypt;

namespace DigitalConstructalWeb.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<bool> UserExistsAsync(string email)
    {
      return await _userRepository.GetByEmailAsync(email) != null;
    }

    public async Task Insert(UserLoginDto userDto)
    {
      var user = _mapper.Map<UserLogin>(userDto);

      user.Password = BC.HashPassword(user.Password);

      await _userRepository.AddAsync(user);
    }

    public async Task<UserLogin?> GetByEmail(string email)
    {
      return await _userRepository.GetByEmailAsync(email);
    }

    public async Task Authenticate(string email, HttpContext httpContext)
    {
      var claims = new List<Claim>
      {
          new Claim(ClaimTypes.Email, email),
      };

      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
      var authProperties = new AuthenticationProperties
      {
        IsPersistent = true,
        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
      };

      await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
    }

  }
}
