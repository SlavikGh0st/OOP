using L03_db_via_ado;
using L04_db_via_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace L04_db_via_ef;

public class Db : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Consts.DefaultConnection);
    }
}