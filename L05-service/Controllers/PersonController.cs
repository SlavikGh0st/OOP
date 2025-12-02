using L05_service.Models;
using L05_service.Storage;
using Microsoft.AspNetCore.Mvc;

namespace L05_service.Controllers;

[ApiController]
[Route("persons")] //нужно придумать путь для доступа к этим методам 
public class PersonController : ControllerBase
{
    private readonly PersonStorage storage;

    public PersonController()
    {
        var db = new Db();
        storage = new PersonStorage(db);
    }
    
    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    public async Task<ActionResult<Person>> GetPerson([FromBody] Person person)
    {
        var isCreated = await storage.CreatePerson(person);
        return !isCreated ? Conflict($"Person with {person.Id} already created") : Ok(person);
    }

    [HttpGet]
    [Route("{personId:guid}")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Person>> GetPerson([FromRoute] Guid personId)
    {
        var person = await storage.GetPerson(personId);
        return person == null ? NotFound("Person not found") : Ok(person);
    }
    
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<Person>>> SearchPersons([FromQuery] string? name)
    {
        var searchOptions = new PersonSearchFields(name);
        var persons = await storage.SearchPersons(searchOptions);
        return Ok(persons);
    }
    
    [HttpDelete]
    [Route("{personId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeletePerson([FromRoute] Guid personId)
    {
        await storage.Delete(personId);
        return Ok();
    }
}