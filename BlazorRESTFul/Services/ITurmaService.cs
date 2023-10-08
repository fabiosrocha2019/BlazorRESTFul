using BlazorRESTFul.Models;

namespace BlazorRESTFul.Service
{
    public interface ITurmaService
    {
        Task AtualizaTurmaAsync(Turma turma);
        Task<List<Turma>> BuscarTodasTurmasAsync();
        Task CadastrarTurmaAsync(Turma turma);
        Task DeletarTurmaAsync(int id);
        Task<Turma> GetByidTurmaAsync(int id);
        Task<int> GetByNameAsync(string name);
    }
}
