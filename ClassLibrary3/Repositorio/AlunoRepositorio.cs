using Modelo.Domain;
using Modelo.infra.Data.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.infra.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public Aluno BuscarId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Aluno> InserirAlunos(Aluno aluno)
        {
            await _bancoContexto.Aluno.AddAsync(aluno);
            await _bancoContexto.SaveChangesAsync();

            return aluno;

        }


    }
}
