using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DigitalConstructalWeb.Models;

namespace DigitalConstructalWeb.Controllers;

public class CardsController : Controller
{
  public IActionResult Basic() => View();
}
