using Dapper;
using System.Data;
using System.Data.Common;

namespace BlazorRESTFul.Handlers
{
    public interface IDapperCommandService<T>
    {
        DbConnection GetConnection();

        int Insert<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        int Update<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        int Delete<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);

        int ExecuteProcedure(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
