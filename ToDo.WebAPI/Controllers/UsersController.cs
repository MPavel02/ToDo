using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.DAL;

namespace ToDo.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class UsersController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(ToDoDbContext context)
    {
        var users = await context.Users.ToListAsync();
        
        return new JsonResult(users);
    }
}