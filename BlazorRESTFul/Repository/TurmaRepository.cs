using BlazorRESTFul.Handlers;
using BlazorRESTFul.Models;
using Dapper;
using System.Data;

namespace BlazorRESTFul.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly IDapperService _dapperDao;

        public TurmaRepository(IDapperService dapperDao)
        {
            _dapperDao = dapperDao;
        }

        public async Task CadastrarTurmaAsync(Turma turma)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@turma", turma.turma);
            dbPara.Add("@ano", turma.Ano);

            try
            {
                await _dapperDao.InsertAsync<int>("PR_INSERE_TURMA", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar turma.", ex);
            }
        }

        public async Task<Turma> GetByidTurmaAsync(int id)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", id);

                var turma = await _dapperDao.GetByIdAsync<Turma>("PR_BUSCA_TURMA_BYID", dbPara, commandType: CommandType.StoredProcedure);
                return turma;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar turma por ID.", ex);
            }
        }

        public async Task<List<Turma>> BuscarTodosTurmasAsync()
        {
            List<Turma> turmas = new List<Turma>();

            var dbPara = new DynamicParameters();
            var alunos = await _dapperDao.GetAllAsync<Turma>("PR_BUSCA_TODAS_TURMAS", dbPara, commandType: CommandType.StoredProcedure);
            return alunos.ToList();
        }

        public async Task<int> AtualizaTurmaAsync(Turma turma)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@id", turma.Id);
            dbPara.Add("@turma", turma.turma);
            dbPara.Add("@ano", turma.Ano);

            try
            {
                return await _dapperDao.UpdateAsync<int>("PR_ATUALIZA_TURMA", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar turma.", ex);
            }
        }

        public async Task<int> GetByNameAsync(string name)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@name", name);

                var turma = await _dapperDao.GetByIdAsync<Turma>("PR_BUSCA_TURMA_BYNAME", dbPara, commandType: CommandType.StoredProcedure);

                if (turma != null && turma.Id > 0)
                {
                    return turma.Id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar turma por nome.", ex);
            }
        }

        public async Task DeletarTurmaAsync(int id)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", id);

                await _dapperDao.ExecuteAsync<int>("PR_DELETA_TURMA", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar turma.", ex);
            }
        }
    }
}
