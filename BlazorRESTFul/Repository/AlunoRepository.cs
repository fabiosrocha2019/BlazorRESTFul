using BlazorRESTFul.Handlers;
using BlazorRESTFul.Models;
using BlazorRESTFul.Service;
using BlazorRESTFul.Handlers;
using Dapper;
using System.Data;

namespace BlazorRESTFul.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDapperService _dapperDao;

        public AlunoRepository(IDapperService dapperDao)
        {
            _dapperDao = dapperDao;
        }

        public async Task<int> CadastrarAlunoAsync(Aluno aluno)
        {

            var dbPara = new DynamicParameters();
            dbPara.Add("@nome", aluno.Nome.ToString());
            dbPara.Add("@usuario", aluno.Usuario.ToString());
            dbPara.Add("@senha", aluno.Senha.ToString());


            var alunoId = Task.FromResult(_dapperDao.InsertAsync<int>("PR_INSERE_ALUNO",
                                            dbPara, commandType: CommandType.StoredProcedure));

            return await alunoId.Result;

        }

        public async Task<Aluno> GetByidAlunoAsync(int id)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", id);

                var aluno = await _dapperDao.GetByIdAsync<Aluno>("PR_BUSCA_ALUNO_BYID", dbPara, commandType: CommandType.StoredProcedure);
                return aluno;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar aluno por ID.", ex);
            }
        }

        public async Task<List<Aluno>> BuscarTodosAlunosAsync()
        {

            var dbPara = new DynamicParameters();
            var alunos = await _dapperDao.GetAllAsync<Aluno>("PR_BUSCA_TODOS_ALUNOS", dbPara, commandType: CommandType.StoredProcedure);
            return alunos.ToList();

        }

        public async Task<int> AtualizaAlunoAsync(Aluno aluno)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@id", aluno.Id);
            dbPara.Add("@nome", aluno.Nome.ToString());
            dbPara.Add("@usuario", aluno.Usuario.ToString());

            try
            {
                return await _dapperDao.UpdateAsync<int>("PR_ATUALIZA_ALUNO", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar aluno.", ex);
            }
        }

        public async Task DeletarAlunoAsync(int id)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", id);

                await _dapperDao.ExecuteAsync<int>("PR_DELETA_ALUNO", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar aluno.", ex);
            }
        }
    }


}
