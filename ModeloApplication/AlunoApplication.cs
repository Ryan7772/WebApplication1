using Modelo.Application.Interfaces;
using Modelo.Domain;
using Modelo.infra.Data.Repositorio;
using Modelo.infra.Data.Repositorio.Interfaces;

namespace Modelo.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepositorio _alunorepositorio;

        public AlunoApplication(IAlunoRepositorio alunoRepositorio)
        {
            _alunorepositorio = alunoRepositorio;
        }

        public Aluno BuscarAluno(int id)
        {
            var aluno = _alunorepositorio.BuscarId(id);
            return aluno;
        }

        public Retorno InserirAluno(Aluno aluno)
        {
            Retorno retorno = new();

            if (aluno != null)
            {
                var mensagem = ValidaAluno(aluno);

                if (mensagem != null)
                { 

                    retorno.CarregaRetorno(false, mensagem, 200);
                    return retorno;
                
                }
                _alunorepositorio.InserirAlunos(aluno);

                retorno.CarregaRetorno(true, "Aluno adicionado com sucesso", 200);

            }
            else
            {
                retorno.CarregaRetorno(true, "Nenhum dado foi informado", 200);
            }

            return retorno;
        }


        private string ValidaAluno(Aluno aluno) 
        {
            string mensagem = "";

            if (aluno.Nome.Any())
                mensagem = "Não é possivelo inserir Nome";

            if (aluno.Nome.Length > 30)
                mensagem = "O nome do Aluno deve conter 30 caracteres!";

            return mensagem;

        }

    }
}