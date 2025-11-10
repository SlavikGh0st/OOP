namespace L03_db_via_ado;

public static class Consts
{
    public const string DefaultServer = @"(LocalDB)\MSSQLLocalDB";
    public const string DefaultDatabase = "master";
    public const string DefaultAuthSchema = "Trusted_Connection=True";

    public static string GetDbConnectionString() =>
        $"Server={DefaultServer};Database={DefaultDatabase};{DefaultAuthSchema};";

    public const string PersonsTable = "Persons";
}