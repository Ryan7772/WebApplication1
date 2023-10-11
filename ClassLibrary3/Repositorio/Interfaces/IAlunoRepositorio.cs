using Modelo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.infra.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Aluno BuscarId(int id);
        Task<Aluno> InserirAlunos(Aluno aluno);
        Task<Aluno>  ListarId(int id);
        Task<Aluno>  Atualizar(Aluno aluno, int id);

        Task<bool> Apagar(int id);


    }
}
