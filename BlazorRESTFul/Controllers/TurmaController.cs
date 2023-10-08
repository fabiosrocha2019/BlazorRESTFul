using BlazorRESTFul.Models;
using BlazorRESTFul.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRESTFul.Controllers
{
    [ApiController]
    [Route("api/Turma")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var turmas = await _turmaService.BuscarTodasTurmasAsync();
                return Ok(turmas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao buscar todas as turmas.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var turma = await _turmaService.GetByidTurmaAsync(id);
                if (turma == null)
                {
                    return NotFound();
                }

                return Ok(turma);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao buscar turma por ID.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Turma turma)
        {
            try
            {
                await _turmaService.CadastrarTurmaAsync(turma);
                return Ok("Turma cadastrada com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao cadastrar turma.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Turma turma)
        {
            try
            {
                await _turmaService.AtualizaTurmaAsync(turma);
                return Ok("Turma atualizada com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao atualizar turma.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _turmaService.DeletarTurmaAsync(id);
                return Ok("Turma deletada com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao deletar turma.");
            }
        }
    }
}
