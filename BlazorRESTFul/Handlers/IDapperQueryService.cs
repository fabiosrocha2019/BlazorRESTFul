using Dapper;
using System.Data.Common;
using System.Data;

namespace BlazorRESTFul.Handlers
{
    public interface IDapperQueryService<T>
    {
        DbConnection GetConnection();

        IEnumerable<T> GetAll<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        T GeTById<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        T GeTByName<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
