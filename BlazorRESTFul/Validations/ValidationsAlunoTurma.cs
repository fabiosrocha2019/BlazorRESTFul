using BlazorProject.Repository;
using BlazorRESTFul.Models;
using BlazorRESTFul.Service;

namespace BlazorRESTFul.Validations
{
    public class ValidationsAlunoTurma : IValidationsAlunoTurma
    {
        private readonly IAlunoService _alunoService;
        private readonly ITurmaService _turmaService;
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;

        public ValidationsAlunoTurma(IAlunoService alunoService, ITurmaService turmaService, IAlunoTurmaRepository alunoTurmaRepository)
        {
            _alunoService = alunoService;
            _turmaService = turmaService;
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public bool VerificaAluno(int alunoId)
        {
            var aluno =  _alunoService.GetByidAlunoAsync(alunoId);
            if (aluno == null)
            {
                return false;
            }          
            
            return true;
        }

        public bool VerificaTurma( int turmaId)
        {
            var turma =  _turmaService.GetByidTurmaAsync(turmaId);
            if (turma == null)
            {
                return false;
            }
            return true;
        }

        public bool VerificaAlunoTurma(int alunoId, int turmaId)
        {
            return _alunoTurmaRepository.VerificaMatriculaAluno(alunoId, turmaId).Result;
        }

    }

}
