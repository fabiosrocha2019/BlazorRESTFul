using Dapper;
using System.Data;
using System.Data.Common;
using System.Dynamic;

namespace BlazorRESTFul.Handlers
{
    public interface IDapperService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        Task<T> GetByIdAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        Task<T> GetByNameAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        DbConnection GetConnection();

        Task<int> InsertAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        Task<T> UpdateAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        Task<int> ExecuteAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
    }

}
