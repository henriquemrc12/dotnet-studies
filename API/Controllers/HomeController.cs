using Microsoft.AspNetCore.Mvc;

namespace dotnet_studies.API.Controllers;

[Route("")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Redirect("~/swagger");
    }
}