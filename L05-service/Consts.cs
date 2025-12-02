namespace L05_service;

public static class Consts
{
    public const string DefaultServer = @"(LocalDB)\MSSQLLocalDB";
    public const string DefaultDatabase = "master";
    public const string DefaultAuthSchema = "Trusted_Connection=True";

    public const string DefaultConnection = $"Server={DefaultServer};Database={DefaultDatabase};{DefaultAuthSchema};";

    public const string PersonsTable = "Persons";
}