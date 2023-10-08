using BlazorRESTFul.Models;

namespace BlazorRESTFul.Service
{
    public interface IAlunoService
    {
        Task CadastrarAlunoAsync(Aluno aluno);
        Task DeletarAlunoAsync(int id);
        Task<Aluno> GetByidAlunoAsync(int id);
        Task<List<Aluno>> BuscarTodosAlunosAsync();
        Task<int> AtualizaAlunoAsync(Aluno aluno);
    }
}
