using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DigitalConstructalWeb.Controllers;

[Authorize]
public class DashboardsController : Controller
{
  public IActionResult Index() => View();
}
