using BlazorRESTFul.Repository;
using BlazorRESTFul.Handlers;
using BlazorRESTFul.Models;
using BlazorRESTFul.Services;

namespace BlazorRESTFul.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunodao;
        private readonly ITurmaRepository _turmaDao;
        private readonly IHashService _hashService;
        //private readonly IDapperCommandService<Aluno> _commandService;
        //private readonly IDapperQueryService<Aluno> _queryService;

        public AlunoService(IAlunoRepository alunoDao, ITurmaRepository turmaDao, IHashService hashService)
        {
            _alunodao = alunoDao;
            _turmaDao = turmaDao;
            _hashService = hashService;
        }

        public async Task CadastrarAlunoAsync(Aluno aluno)
        {
            try
            {
                aluno.Senha = _hashService.HashPassword(aluno.Senha);
                await _alunodao.CadastrarAlunoAsync(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar aluno.", ex);
            }
        }

        public async Task DeletarAlunoAsync(int id)
        {
            try
            {
                await _alunodao.DeletarAlunoAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar aluno.", ex);
            }
        }

        public async Task<Aluno> GetByidAlunoAsync(int id)
        {
            try
            {
                return await _alunodao.GetByidAlunoAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar aluno por ID.", ex);
            }
        }

        public async Task<List<Aluno>> BuscarTodosAlunosAsync()
        {
            try
            {
                return await _alunodao.BuscarTodosAlunosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os alunos.", ex);
            }
        }

        public async Task<int> AtualizaAlunoAsync(Aluno aluno)
        {
            try
            {
                return await _alunodao.AtualizaAlunoAsync(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar aluno.", ex);
            }
        }

    }
}
