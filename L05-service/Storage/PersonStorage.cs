using L05_service.Models;
using Microsoft.EntityFrameworkCore;

namespace L05_service.Storage;

public class PersonStorage
{
    private readonly Db storage;

    public PersonStorage(Db storage)
    {
        this.storage = storage;
    }

    public async Task<bool> CreatePerson(Person person)
    {
        if (await GetPerson(person.Id) != null)
            return false;

        await storage.AddAsync(person);
        await storage.SaveChangesAsync();
        return true;
    }

    public Task<Person?> GetPerson(Guid id) =>
        storage.Persons.FirstOrDefaultAsync(person => person.Id == id);

    public Task<List<Person>> SearchPersons(PersonSearchFields searchFields) =>
        storage.Persons.Where(person => searchFields.Name == null || person.FirstName == searchFields.Name).ToListAsync();

    public async Task Delete(Guid id)
    {
        await storage.Persons.Where(person => person.Id == id).ExecuteDeleteAsync();
        await storage.SaveChangesAsync();
    }
}
