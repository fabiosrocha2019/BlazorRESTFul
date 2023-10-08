using BlazorRESTFul.Models;
using BlazorRESTFul.Handlers;
using BlazorRESTFul.Repository;

namespace BlazorRESTFul.Service
{
    public class TurmaService : ITurmaService
    {
        private readonly IDapperService _dapperDao;
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(IDapperService dapperDao, ITurmaRepository turmaRepository)
        {
            _dapperDao = dapperDao;
            _turmaRepository = turmaRepository;
        }

        public async Task AtualizaTurmaAsync(Turma turma)
        {
            try
            {
                await _turmaRepository.AtualizaTurmaAsync(turma);
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro ao atualizar a turma, entre em contato com o administrador do sistema");
                throw;
            }
        }

        public async Task<List<Turma>> BuscarTodasTurmasAsync()
        {
            return await _turmaRepository.BuscarTodosTurmasAsync();
        }

        public async Task CadastrarTurmaAsync(Turma turma)
        {
            try
            {
                if (await _turmaRepository.GetByNameAsync(turma.turma) < 1 )
                {
                    await _turmaRepository.CadastrarTurmaAsync(turma);
                    Console.WriteLine("Turma cadastrada com sucesso");
                }
                else
                {
                    Console.WriteLine("Turma já existente, não é possível prosseguir com o cadastro");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro ao cadastrar a turma, entre em contato com o administrador do sistema");
                throw;
            }
        }

        public async Task DeletarTurmaAsync(int id)
        {
            try
            {
                await _turmaRepository.DeletarTurmaAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Turma> GetByidTurmaAsync(int id)
        {
            try
            {
                return await _turmaRepository.GetByidTurmaAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetByNameAsync(string name)
        {
            try
            {
                return await _turmaRepository.GetByNameAsync(name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
