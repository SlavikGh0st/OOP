using System.Data.SqlClient;
using L03_db_via_ado.Models;

namespace L03_db_via_ado;

public class PersonStorage : IDisposable, IAsyncDisposable
{
    private const string connectionString = Consts.DefaultConnection;
    private const string tableName = Consts.PersonsTable;

    private SqlConnection connection;

    public PersonStorage()
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    public async Task<Guid?> CreatePerson(string name, int age)
    {
        var personId = Guid.NewGuid();
        var createQuery = $"INSERT INTO {tableName} (Id, Name, Age) VALUES (@Id, @Name, @Age)";

        await using var command = new SqlCommand(createQuery, connection);
        command.Parameters.AddWithValue("@Id", personId);
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Age", age);
        var commandResult = await command.ExecuteNonQueryAsync();
        if (commandResult == 1)
            return personId;
        
        return null;
    }

    public async Task<Person?> GetPerson(Guid id)
    {
        var getQuery = $"SELECT Name, Age FROM {tableName} WHERE Id = @id";

        await using var command = new SqlCommand(getQuery, connection);
        command.Parameters.AddWithValue("@id", id);

        var commandResult = await command.ExecuteReaderAsync();
        if (commandResult.Read())
            return new Person(commandResult["Name"].ToString()!, (int)commandResult["Age"]);

        return null;
    }

    public void Dispose()
    {
        connection.Close();
        connection.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await connection.CloseAsync();
        await connection.DisposeAsync();
    }
}