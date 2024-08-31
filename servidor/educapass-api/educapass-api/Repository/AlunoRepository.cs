using educapass_api.Db;
using educapass_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educapass_api.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly BancoContext _bancoContext;
        public AlunoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _bancoContext.Aluno.Add(aluno);
            _bancoContext.SaveChanges();
            return aluno;
        }

        public AlunoModel AlunoById(int id)
        {
            return _bancoContext.Aluno.FirstOrDefault(x => x.Id == id);
        }

        public List<AlunoModel> GetAlunos()
        {
            return _bancoContext.Aluno.Include(t => t.Clase).ToList();
        }

        public bool Deletar(int id)
        {
            AlunoModel deletarAluno = AlunoById(id);
            if (deletarAluno == null)
            {
                return false;
            }
            _bancoContext.Aluno.Remove(deletarAluno);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
