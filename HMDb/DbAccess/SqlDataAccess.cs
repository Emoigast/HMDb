using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace HMDb.DbAccess;

public class SqlDataAccess
{
    private readonly IConfiguration _configuration;
    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(sql, parameters);
    }
    public async Task SaveData<T>(string sql, T parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
        await connection.ExecuteAsync(sql, parameters);
    }
}
