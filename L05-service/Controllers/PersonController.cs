using L05_service.Models;
using L05_service.Storage;
using Microsoft.AspNetCore.Mvc;

namespace L05_service.Controllers;

//[ApiController]
//[Route("route")] //нужно придумать путь для доступа к этим методам 
public class PersonController : ControllerBase
{
    private readonly PersonStorage storage;

    public PersonController()
    {
        var db = new Db();
        storage = new PersonStorage(db);
    }

    //тип HTTP запроса
    //маршрут Route
    //описание ответов
    public async Task<ActionResult<IList<Person>>> SearchPersons( /* что-то должно быть на входе */)
    {
        throw new NotImplementedException();
    }

    //тип HTTP запроса
    //маршрут Route
    //описание ответов
    public async Task<ActionResult<Person>> CreatePerson( /* что-то должно быть на входе */)
    {
        throw new NotImplementedException();
    }

    //тип HTTP запроса
    //маршрут Route
    //описание ответов
    public async Task<ActionResult<Person>> GetPerson( /* что-то должно быть на входе */)
    {
        throw new NotImplementedException();
    }

    //тип HTTP запроса
    //маршрут Route
    //описание ответов
    public async Task<ActionResult> DeletePerson( /* что-то должно быть на входе */)
    {
        throw new NotImplementedException();
    }
}