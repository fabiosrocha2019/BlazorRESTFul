using BlazorRESTFul.Models;

namespace BlazorRESTFul.Service
{
    public interface IAlunoTurmaService
    {
        Task<int> MatricularAlunoEmTurmaAsync(int alunoId, int turmaId);
        Task<int> RetirarAlunoDeTurmaAsync(int alunoId, int turmaId);
        Task<List<Turma>> BuscarTurmasDeAlunoAsync(int alunoId);
    }
}
