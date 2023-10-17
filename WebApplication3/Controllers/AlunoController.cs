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
        public async Task<IActionResult> InserirosAlunos([FromBody] Aluno aluno)
        {
            Retorno retorno = new Retorno();

            try
            {
                retorno = _alunoApplication.InserirAluno(aluno);
                return Ok(retorno);
            }

            catch (Exception)
            {
                return BadRequest("Erro");
            }

        }
    
        [HttpPut("{id}")]
        
        public async Task<ActionResult<Aluno>> Editar([FromBody] Aluno alunos,  int id)
        {
            alunos.Id = id;
            Aluno aluno = await _alunorepositorio.Atualizar(alunos, id);
            return Ok(aluno);
        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> ApagarAluno( int id)
        {
            bool apagado = await _alunorepositorio.Apagar(id);
            return Ok(apagado);

        }


    }


}

