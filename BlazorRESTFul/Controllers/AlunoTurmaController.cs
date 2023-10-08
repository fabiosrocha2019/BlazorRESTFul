using System;
using System.Threading.Tasks;
using BlazorRESTFul.Models;
using BlazorRESTFul.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRESTFul.Controllers
{
    [ApiController]
    [Route("api/AlunoTurma")]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurmaService _alunoTurmaService;

        public AlunoTurmaController(IAlunoTurmaService alunoTurmaService)
        {
            _alunoTurmaService = alunoTurmaService;
        }

        [HttpPost("MatricularAluno")]
        public async Task<IActionResult> MatricularAluno(int alunoId, int turmaId)
        {
            try
            {
                var result = await _alunoTurmaService.MatricularAlunoEmTurmaAsync(alunoId, turmaId);
                return Ok($"Aluno matriculado com sucesso na turma {turmaId}");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao matricular aluno em turma.");
            }
        }

        [HttpDelete("RetirarAluno")]
        public async Task<IActionResult> RetirarAluno(int alunoId, int turmaId)
        {
            try
            {
                await _alunoTurmaService.RetirarAlunoDeTurmaAsync(alunoId, turmaId);
                return Ok($"Aluno retirado com sucesso da turma {turmaId}");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao retirar aluno da turma.");
            }
        }

        [HttpGet("TurmasDeAluno")]
        public async Task<IActionResult> TurmasDeAluno(int alunoId)
        {
            try
            {
                var turmas = await _alunoTurmaService.BuscarTurmasDeAlunoAsync(alunoId);
                return Ok(turmas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao buscar turmas do aluno.");
            }
        }
    }
}
