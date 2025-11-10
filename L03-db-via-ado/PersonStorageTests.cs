using FluentAssertions;
using L03_db_via_ado.Models;
using NUnit.Framework;

namespace L03_db_via_ado;

public class PersonStorageTests
{
    [Test]
    public async Task CreatePerson_WorksCorrectly()
    {
        var personStorage = new PersonStorage();
        var expected = new Person("Слава", 33);

        var personId = await personStorage.CreatePerson(expected.Name, expected.Age);
        var actual = await personStorage.GetPerson(personId!.Value);

        actual.Should().BeEquivalentTo(expected);
    }
}