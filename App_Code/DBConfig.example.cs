using System;

public class DBConfigExample
{
    private string connectionString;

    public DBConfigExample()
    {
        // Modifica questa stringa con i tuoi parametri locali
        connectionString = "Data Source=FRANCESCO\\SQLEXPRESS;Initial Catalog=AUTOSALONI;Integrated Security=True;Encrypt=False";
    }

    public string GetConnectionString()
    {
        return connectionString;
    }
}