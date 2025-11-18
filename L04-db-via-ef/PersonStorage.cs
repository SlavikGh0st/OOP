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
        //AddAsync()
        //SaveChanges()
        throw new NotImplementedException();
    }

    public async Task<Person?> GetPerson(Guid id)
    {
        //FirstOrDefaultAsync()
        throw new NotImplementedException();
    }
    
    public async Task<IList<Person>> SearchPersonsByName(string name)
    {
        //ToListAsync()
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        //ExecuteDeleteAsync()
        throw new NotImplementedException();
    }
}