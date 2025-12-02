using L05_service.Models;
using Microsoft.EntityFrameworkCore;

namespace L05_service.Storage;

public class Db : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Consts.DefaultConnection);
    }
}