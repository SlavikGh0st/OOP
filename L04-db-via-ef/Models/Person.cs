using System.ComponentModel.DataAnnotations.Schema;

namespace L04_db_via_ef.Models;

public class Person
{
    public Guid Id { get; set; }

    [Column("Name")]
    public string FirstName { get; set; }

    public int Age { get; set; }
}