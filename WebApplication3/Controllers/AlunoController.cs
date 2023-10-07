using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Application.Interfaces;
using Modelo.Domain;
using Modelo.infra.Data.Repositorio.Interfaces;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;

        private readonly IAlunoRepositorio _alunorepositorio;


        public AlunoController(IAlunoApplication alunoApplication,IAlunoRepositorio alunoRepositorio)
        {
            _alunoApplication = alunoApplication;

            _alunorepositorio = alunoRepositorio;

        }
        [HttpGet("BuscaroAluno/{id}")]

        public async Task<IActionResult> BuscaroAluno(int id)
        {
            try
            {
                var aluno = _alunoApplication.BuscarAluno(id);
                return Ok(aluno);
            }

            catch (Exception)
            {
                return BadRequest("Erro");
            }

        }
        [HttpPost("InserirAluno")]
        public async Task<ActionResult<Aluno>> InserirosAlunos([FromBody] Aluno alunos)
        {
            try
            {
                Aluno aluno = await _alunorepositorio.InserirAlunos(alunos);
                return Ok(alunos);
            }

            catch (Exception)
            {
                return BadRequest("Erro");
            }

        }

    }
}
