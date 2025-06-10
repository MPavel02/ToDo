using Microsoft.AspNetCore.Mvc;

namespace ToDo.WebAPI.Controllers.UserController;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return new JsonResult("Good Work");
    }
}