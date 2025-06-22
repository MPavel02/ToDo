using Microsoft.AspNetCore.Mvc;
using ToDo.WebAPI.Filters;

namespace ToDo.WebAPI.Controllers;

[ApiController]
[TypeFilter<ApiExceptionFilter>]
[Route("api/v1/[controller]")]
public class ApiBaseController : ControllerBase;