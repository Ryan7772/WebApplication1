using Microsoft.EntityFrameworkCore;
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
        public async Task<Aluno> ListarId(int id)
        {
            return await _bancoContexto.Aluno.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Aluno> Atualizar(Aluno aluno, int id)
        {
            Aluno alunoDb = await ListarId(id);

            if (alunoDb == null) 
            {
                throw new Exception($"O Id:{id} do aluno não foi encontrado no banco de dados.");
            }

            alunoDb.Nome = aluno.Nome;


            _bancoContexto.Aluno.Update(alunoDb);
            await  _bancoContexto.SaveChangesAsync();

            return alunoDb;

        }
        public async Task<bool> Apagar(int id)
        {
            Aluno alunoDb = await ListarId(id);

            if (alunoDb == null)
            {
                throw new Exception($"O Id:{id} do aluno não foi encontrado no banco de dados.");
            }

            _bancoContexto.Aluno.Remove(alunoDb);
            _bancoContexto.SaveChanges();

            return true;

        }


    }
}
