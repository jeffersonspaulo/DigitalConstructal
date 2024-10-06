using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DigitalConstructalWeb.Models;

namespace DigitalConstructalWeb.Controllers;

public class IconsController : Controller
{
  public IActionResult RiIcons() => View();
}
