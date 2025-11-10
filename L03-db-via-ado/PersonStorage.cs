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
        //$"INSERT INTO {tableName} (Id, Name, Age) VALUES (@Id, @Name, @Age)";
        //command.Parameters.AddWithValue();
        //command.ExecuteNonQueryAsync();
        throw new NotImplementedException();
    }

    public async Task<Person?> GetPerson(Guid id)
    {
        //$"SELECT Name, Age FROM {tableName} WHERE Id = @id";
        //await command.ExecuteReaderAsync()
        //if (commandResult.Read())
        //commandResult["Name"].ToString()!
        throw new NotImplementedException();
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