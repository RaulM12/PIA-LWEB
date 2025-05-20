using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public class ConexionMySQL
{
    private readonly string _connectionString;

    public ConexionMySQL(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MySqlConnection");
    }

    public async Task<List<string>> ObtenerUsuarios()
    {
        var usuarios = new List<string>();

        using var conexion = new MySqlConnection(_connectionString);
        await conexion.OpenAsync();

        var query = "SELECT Basederecetas FROM usuarios"; 

        using var comando = new MySqlCommand(query, conexion);
        using var lector = await comando.ExecuteReaderAsync();

        while (await lector.ReadAsync())
        {
            usuarios.Add(lector.GetString("nombre"));
        }

        return usuarios;
    }
}
