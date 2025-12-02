using Microsoft.AspNetCore.Mvc;

namespace L05_service.Controllers;

[ApiController]
[Route("")]
public class PingController : ControllerBase
{
    [HttpGet]
    [Route("ping")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public ActionResult<string> Ping() => "pong";

    [HttpGet]
    [Route("hello")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<string> HelloFromQuery([FromQuery] string name) => $"Hello, {name}!";
    
    [HttpGet]
    [Route("hello/{name}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<string> HelloFromRoute([FromRoute] string name) => $"Hello, {name}!";
    
    [HttpPost]
    [Route("hello")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<string> HelloFromBody([FromBody] string name) => $"Hello, {name}!";
}