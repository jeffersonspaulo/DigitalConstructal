using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DigitalConstructalWeb.Models;

namespace DigitalConstructalWeb.Controllers;

public class FormLayoutsController : Controller
{
public IActionResult Horizontal() => View();
public IActionResult Vertical() => View();
}
