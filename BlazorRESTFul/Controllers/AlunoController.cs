using BlazorRESTFul.Models;
using BlazorRESTFul.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRESTFul.Controllers
{
    [ApiController]
    [Route("api/Aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var alunos = await _alunoService.BuscarTodosAlunosAsync();
                return Ok(alunos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao buscar todos os alunos.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var aluno = await _alunoService.GetByidAlunoAsync(id);
                if (aluno == null)
                {
                    return NotFound();
                }

                return Ok(aluno);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao buscar aluno por ID.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                await _alunoService.CadastrarAlunoAsync(aluno);
                return Ok("Aluno cadastrado com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao cadastrar aluno.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno aluno)
        {
            try
            {
                await _alunoService.AtualizaAlunoAsync(aluno);
                return Ok("Aluno atualizado com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao atualizar aluno.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _alunoService.DeletarAlunoAsync(id);
                return Ok("Aluno deletado com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao deletar aluno.");
            }
        }
    }
}
