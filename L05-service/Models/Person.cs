using System.ComponentModel.DataAnnotations.Schema;

namespace L05_service.Models;

public class Person
{
    public Guid Id { get; set; }

    [Column("Name")]
    public string FirstName { get; set; }

    public int Age { get; set; }
}