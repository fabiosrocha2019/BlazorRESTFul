using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using static Dapper.SqlMapper;

namespace BlazorRESTFul.Handlers
{
    public class DapperService : IDapperService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _config;
        private readonly string _conn;

        public DapperService(IConfiguration _config)
        {
            _config = _config;
            _conn = _config.GetConnectionString("DefaultConnection");
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(_conn);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Query<T>(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public async Task<T> GetByIdAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);

            try
            {
                return (await db.QueryAsync<T>(procedureName, dynamicParameters, commandType: commandType)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByNameAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);

            try
            {
                return (await db.QueryAsync<T>(procedureName, dynamicParameters, commandType: commandType)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<int> InsertAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {

            using IDbConnection db = new SqlConnection(_conn);
            int result;
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();

                try
                {
                    result = db.Query<int>(procedureName, dynamicParameters, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();


                }

            }
            catch (Exception e)
            {
                throw;
            }

            return result;

        }

        public async Task<T> UpdateAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);

            try
            {
                return (await db.QueryAsync<T>(procedureName, dynamicParameters, commandType: commandType)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ExecuteAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Execute(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}

