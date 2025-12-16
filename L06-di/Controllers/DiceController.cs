using System.Text;
using L06_di.Models;
using Microsoft.AspNetCore.Mvc;

namespace L06_di.Controllers;

[ApiController]
[Route("dice")]
public class DiceController : ControllerBase
{
    private readonly DiceRoller roller1;
    private readonly DiceRoller roller2;

    public DiceController(DiceRoller roller1, DiceRoller roller2)
    {
        this.roller1 = roller1;
        this.roller2 = roller2;
    }

    [HttpGet("")]
    public string Get()
    {
        return $"Roll #{roller1.DiceId}: {roller1.Roll()}";
    }

    [HttpGet("x2")]
    public string GetX2()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Roll #{roller1.DiceId}: {roller1.Roll()}");
        sb.AppendLine($"Roll #{roller2.DiceId}: {roller2.Roll()}");
        return sb.ToString();
    }

    [HttpGet("sum/{count:int}")]
    public ActionResult<int> Sum([FromRoute] int count)
    {
        if (count is < 1 or > 100)
            return BadRequest("Количество бросков должно быть больше 0 и не больше 100");
        
        return Enumerable.Range(1, count).Select(_ => roller1.Roll()).Sum();
    }
}