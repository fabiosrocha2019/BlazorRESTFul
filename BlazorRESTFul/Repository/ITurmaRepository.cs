using BlazorRESTFul.Models;
using BlazorRESTFul.Handlers;

namespace BlazorRESTFul.Repository
{
    public interface ITurmaRepository
    {
        Task CadastrarTurmaAsync(Turma turma);
        Task<Turma> GetByidTurmaAsync(int id);
        Task<List<Turma>> BuscarTodosTurmasAsync();
        Task<int> AtualizaTurmaAsync(Turma turma);
        Task<int> GetByNameAsync(string name);
        Task DeletarTurmaAsync(int id);
    }
}
