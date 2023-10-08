using BlazorRESTFul.Models;
using BlazorRESTFul.Handlers;

namespace BlazorRESTFul.Repository
{
    public interface IAlunoRepository
    {
        Task<int> CadastrarAlunoAsync(Aluno aluno);
        Task<Aluno> GetByidAlunoAsync(int id);
        Task<List<Aluno>> BuscarTodosAlunosAsync();
        Task<int> AtualizaAlunoAsync(Aluno aluno);
        Task DeletarAlunoAsync(int id);
    }
}
