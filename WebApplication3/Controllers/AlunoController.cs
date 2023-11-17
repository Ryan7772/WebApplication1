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
        [HttpGet("BuscarDadosAlunos")]
        public async Task<IActionResult> BuscarDadosAlunos()
        {
            Retorno<List<Aluno>> retorno = new(null);
            try
            {
                var alunos = _alunorepositorio.BuscarAlunos();


                if (alunos.Any())
                {
                    retorno.CarregaRetorno(alunos, true, "Consulta realizada com sucesso", 200);
                }
                else
                {
                    retorno.CarregaRetorno(true, "Nenhum aluno encontrado", 204);
                }

                return Ok(retorno);

            }
            catch (Exception e)
            {
                retorno.CarregaRetorno(true, e.Message, 400);
                return BadRequest(retorno);
            }

        }

        [HttpPost("InserirAluno")]
        public async Task<ActionResult<Aluno>> InserirosAlunos([FromBody] Aluno aluno)
        {
            Retorno retorno = new Retorno();
            try
            {
                await _alunorepositorio.InserirAlunos(aluno);
                retorno.CarregaRetorno(true, "Aluno foi adicionado com sucesso", 200);
                return Ok(retorno);
            }

            catch (Exception)
            {
                retorno.CarregaRetorno(false, "Aluno não pode ser inserido", 400);
                return BadRequest(retorno);
            }

        }
    
        [HttpPut("{id}")]
        
        public async Task<ActionResult<Aluno>> Editar([FromBody] Aluno alunos,  int id)
        { 
            Retorno retorno = new Retorno();
            try
            {
                alunos.Id = id;
                Aluno aluno = await _alunorepositorio.Atualizar(alunos, id);
                retorno.CarregaRetorno(true, "Aluno foi Editado com Sucesso", 200);
                return Ok(retorno);
            }

            catch (Exception)
            {
                retorno.CarregaRetorno(false, "Aluno não pode ser Editado", 400);
                return BadRequest(retorno);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> ApagarAluno( int id)
        {
            Retorno retorno = new Retorno();
            try
            {
                bool apagado = await _alunorepositorio.Apagar(id);
                retorno.CarregaRetorno(true, "Aluno foi Excluido com sucesso", 200);
                return Ok(retorno);
            }

            catch (Exception)
            {
                retorno.CarregaRetorno(false, "Aluno não pode ser inserido", 400);
                return BadRequest(retorno);
            }
        }


    }


}

