using Dapper;
using HandleBudgets2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HandleBudgets2.Services
{
    public interface IRepositoryAccountTypes
    {
        Task Create(AccountType accountType);
        Task<bool> Exists(string name, int userId);
    }
    public class RepositoryAccountTypes: IRepositoryAccountTypes
    {
        private readonly string connectionString;
        public RepositoryAccountTypes(IConfiguration configuration)
        {
            //entra en el connectionstring y busca el defaultconnection
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Create(AccountType accountType)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO account_types (name, user_id, [order]) 
                                                VALUES (@Name, @UserId, 0)
                                                SELECT SCOPE_IDENTITY();", accountType);
            accountType.Id = id;
        }

        public async Task<bool> Exists(string name, int userId)
        {
            using var connection = new SqlConnection(connectionString);
            var exists = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM account_types WHERE name = @Name AND user_id = @UserId", new {name, userId});
            return exists == 1;
            // si existe un registro el valor sera 1, y sino sera 0. 1=true y 0=false
        }
    }
}
