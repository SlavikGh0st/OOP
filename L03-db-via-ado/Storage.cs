using System.Data.SqlClient;

namespace L03_db_via_ado;

public class Storage
{
    private readonly string connectionString;

    public Storage(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException("Empty connection string is not allowed.");

        this.connectionString = connectionString;
    }

    public async Task CreateTable(string tableName)
    {
        var createTableSql = $"""
                              IF OBJECT_ID('{tableName}', 'U') IS NULL
                                BEGIN
                                    CREATE TABLE {tableName} (
                                        Id INT NOT NULL PRIMARY KEY IDENTITY,
                                            Name NVARCHAR(255),
                                            Age INT
                                        );
                                END;
                              """;


        await using var connection = new SqlConnection(connectionString);
        await using var command = new SqlCommand(createTableSql, connection);
        try
        {
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
            Console.WriteLine($"Table '{tableName}' check completed. Created if it didn't exist.");
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
        }
    }

    public async Task EnsureConnectionSuccess()
    {
        await using var connection = new SqlConnection(connectionString);
        Console.WriteLine($"Подключение открыто: {connection.ClientConnectionId}");
        await connection.CloseAsync();
    }
}