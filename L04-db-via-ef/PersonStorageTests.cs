using FluentAssertions;
using L04_db_via_ef.Models;
using NUnit.Framework;

namespace L04_db_via_ef;

public class PersonStorageTests
{
    private PersonStorage personStorage = new(new Db());

    [Test]
    public async Task CreatePerson_WorksCorrectly()
    {
        var expected = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "Willy",
            Age = 18,
        };

        await personStorage.CreatePerson(expected);

        var actual = await personStorage.GetPerson(expected.Id);
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public async Task SearchPersonsByName_WorksCorrectly()
    {
        var expected = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "Billy",
            Age = 19,
        };
        await personStorage.CreatePerson(expected);

        var searchResult = await personStorage.SearchPersonsByName(expected.FirstName);

        searchResult.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public async Task DeletePerson_WorksCorrectly()
    {
        var personForDelete = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "Dilly",
            Age = 20,
        };
        await personStorage.CreatePerson(personForDelete);

        await personStorage.Delete(personForDelete.Id);

        var getResult = await personStorage.GetPerson(personForDelete.Id);
        getResult.Should().BeNull();
    }
}