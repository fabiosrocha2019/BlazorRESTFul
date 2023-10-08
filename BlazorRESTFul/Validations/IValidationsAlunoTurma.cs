namespace BlazorRESTFul.Validations
{
    public interface IValidationsAlunoTurma
    {
        bool VerificaAluno(int alunoId);
        bool VerificaTurma(int turmaId);
        bool VerificaAlunoTurma(int alunoId, int turmaId);
    }
}
