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

      



        private string ValidaAluno(Aluno aluno) 
        {
            string mensagem = "Aluno adicionado com sucesso";

            if (aluno.Nome.Any())
                mensagem = "Não é possivel inserir Nome";

            if (aluno.Nome.Length > 30)
                mensagem = "O nome do Aluno deve conter 30 caracteres!";

            return mensagem;

        }

    }
}