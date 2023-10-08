using BlazorRESTFul.Handlers;
using BlazorRESTFul.Models;
using Dapper;
using System.Data;
using System.Data.Common;

namespace BlazorProject.Repository
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly IDapperService _dapperDao;

        public AlunoTurmaRepository(IDapperService dapperDao)
        {
            _dapperDao = dapperDao;
        }
        public Task<int> ExecuteAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByNameAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public DbConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }



        public async Task<int> MatricularAlunoEmTurmaAsync(int alunoId, int turmaId)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@aluno_id", alunoId);
            dbPara.Add("@turma_id", turmaId);

            var result = Task.FromResult(_dapperDao.InsertAsync<int>("PR_INSERE_ALUNO_TURMA",
                                            dbPara, commandType: CommandType.StoredProcedure));
            return await result.Result;
        }
        public async Task<List<Turma>> BuscarTurmasDeAlunoAsync(int alunoId)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@aluno_id", alunoId);
            var turmas = await _dapperDao.GetAllAsync<Turma>("PR_BUSCA_TURMAS_ALUNO", dbPara, commandType: CommandType.StoredProcedure);
            return turmas.ToList();

        }

        public async Task<int> RetirarAlunoDeTurmaAsync(int alunoId, int turmaId)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@aluno_id", alunoId);
                dbPara.Add("@turma_id", turmaId);

                return await _dapperDao.ExecuteAsync<int>("PR_RETIRA_ALUNO_TURMA", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retirar aluno de turma", ex);
            }
        }

        public async Task<bool> VerificaMatriculaAluno(int alunoId, int turmaId)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@aluno_id", alunoId);
                dbPara.Add("@turma_id", turmaId);

                var matricula = await _dapperDao.GetByIdAsync<int>("PR_VERIFICA_MATRICULA_EXISTENTE", dbPara, commandType: CommandType.StoredProcedure);

                if (matricula != null && matricula > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar matricula aluno.", ex);
            }
        }

    }
}
