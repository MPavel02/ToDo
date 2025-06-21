using Microsoft.AspNetCore.Mvc;
using ToDo.WebAPI.Filters;

namespace ToDo.WebAPI.Controllers;

[ApiController]
[TypeFilter<ApiExceptionFilter>]
public class ApiBaseController : ControllerBase;