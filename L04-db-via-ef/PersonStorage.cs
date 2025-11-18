using L04_db_via_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace L04_db_via_ef;

public class PersonStorage
{
    private readonly Db storage;

    public PersonStorage(Db storage)
    {
        this.storage = storage;
    }

    public async Task CreatePerson(Person person)
    {
        await storage.Persons.AddAsync(person);
        await storage.SaveChangesAsync();
    }

    public async Task<Person?> GetPerson(Guid id)
    {
        var person = await storage.Persons.Where(person => person.Id == id).FirstOrDefaultAsync();
        return person;
    }
    
    public async Task<IList<Person>> SearchPersonsByName(string name)
    {
        var persons = await storage.Persons.Where(person => person.FirstName == name).ToListAsync();
        return persons;
    }
    
    public async Task Delete(Guid id)
    {
        await storage.Persons.Where(person => person.Id == id).ExecuteDeleteAsync();
        await storage.SaveChangesAsync();
    }
}