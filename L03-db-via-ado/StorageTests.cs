using FluentAssertions;
using NUnit.Framework;

namespace L03_db_via_ado;

public class StorageTests
{
    private readonly Storage storage = new(Consts.GetDbConnectionString());
    
    [Test]
    public async Task OpenConnection_Master_ShouldNotThrow()
    {
        var checkConnection = async () => await storage.EnsureConnectionSuccess();

        await checkConnection.Should().NotThrowAsync();
    }
    
    [Test]
    public async Task CreateTable_Persons_ShouldNotThrow()
    {
        var createTable = async () => await storage.CreateTable(Consts.PersonsTable);

        await createTable.Should().NotThrowAsync();
    }
}