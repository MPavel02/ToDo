using Microsoft.AspNetCore.Mvc;

namespace ToDo.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class UsersController : ApiBaseController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return new JsonResult("Good Work");
    }
}