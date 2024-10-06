using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DigitalConstructalWeb.Models;

namespace DigitalConstructalWeb.Controllers;

public class FormsController : Controller
{
  public IActionResult BasicInputs() => View();
  public IActionResult InputGroups() => View();
}
