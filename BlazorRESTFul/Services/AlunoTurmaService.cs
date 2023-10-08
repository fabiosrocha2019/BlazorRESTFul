using BlazorProject.Repository;
using BlazorRESTFul.Models;
using BlazorRESTFul.Validations;

namespace BlazorRESTFul.Service
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly IAlunoService _alunoService;
        private readonly ITurmaService _turmaService;
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IValidationsAlunoTurma _validationsAlunoTurma;

        public AlunoTurmaService(IAlunoService alunoService, ITurmaService turmaService, IAlunoTurmaRepository alunoTurmaRepository, IValidationsAlunoTurma validationsAlunoTurma)
        {
            _alunoService = alunoService;
            _turmaService = turmaService;
            _alunoTurmaRepository = alunoTurmaRepository;
            _validationsAlunoTurma = validationsAlunoTurma;
        }

        public async Task<int> MatricularAlunoEmTurmaAsync(int alunoId, int turmaId)
        {
            if (!_validationsAlunoTurma.VerificaAluno(alunoId))
            {
                Console.WriteLine("Valor de aluno inválido, verifique a solicitação.");
                return 0;
            }
                
            if (!_validationsAlunoTurma.VerificaTurma(turmaId))
            {
                Console.WriteLine("Valor de turma inválido, verifique a solicitação.");
                return 0;
            }
            if (_validationsAlunoTurma.VerificaAlunoTurma(alunoId, turmaId))
            {
                Console.WriteLine("Aluno já matriculado nesta turma");
                return 0;
            }                

            try
            {
                return await _alunoTurmaRepository.MatricularAlunoEmTurmaAsync(alunoId, turmaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar aluno.", ex);
            }

        }

        public async Task<int> RetirarAlunoDeTurmaAsync(int alunoId, int turmaId)
        {

            if (!_validationsAlunoTurma.VerificaAluno(alunoId))
            {
                Console.WriteLine("Valor de aluno inválido, verifique a solicitação.");
                return 0;
            }

            if (!_validationsAlunoTurma.VerificaTurma(turmaId))
            {
                Console.WriteLine("Valor de turma inválido, verifique a solicitação.");
                return 0;
            }

            try
            {
                return await _alunoTurmaRepository.RetirarAlunoDeTurmaAsync(alunoId, turmaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao desmatricular aluno.", ex);
            }

        }

        public async Task<List<Turma>> BuscarTurmasDeAlunoAsync(int alunoId)
        {
            
            try
            {
                return await _alunoTurmaRepository.BuscarTurmasDeAlunoAsync(alunoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os alunos.", ex);
            }



        }
    }
}
