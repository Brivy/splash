using Microsoft.AspNetCore.Mvc;
using Splash.Api.Models.System;

namespace Splash.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SystemController(ILogger<SystemController> logger) : ControllerBase
{
    private readonly ILogger<SystemController> _logger = logger;

    [HttpPost]
    [Route("health")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult HealthCheck([FromBody] HealthRequest healthRequest)
    {
        _logger.LogInformation("Ping");
        return Ok();
    }
}