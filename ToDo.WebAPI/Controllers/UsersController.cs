using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Interfaces;
using ToDo.Domain.Models.Users;

namespace ToDo.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class UsersController(IUserService userService) : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto userDto)
    {
        var result = await userService.Create(userDto);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await userService.GetAll();
        
        return Ok(result);
    }
}