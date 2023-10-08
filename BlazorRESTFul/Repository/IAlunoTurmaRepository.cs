using BlazorRESTFul.Handlers;
using BlazorRESTFul.Models;

namespace BlazorProject.Repository
{
    public interface IAlunoTurmaRepository : IDapperService
    {
        Task<int> MatricularAlunoEmTurmaAsync(int alunoId, int turmaId);
        Task<List<Turma>> BuscarTurmasDeAlunoAsync(int alunoId);
        Task<int> RetirarAlunoDeTurmaAsync(int alunoId, int turmaId);
        Task<bool> VerificaMatriculaAluno(int alunoId, int turmaId);

    }
}
