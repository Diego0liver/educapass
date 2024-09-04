using educapass_api.Db;
using educapass_api.Migrations;
using educapass_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educapass_api.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly BancoContext _bancoContext;
        public ProfessorRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ProfessorModel Adicionar(ProfessorModel professor)
        {
            _bancoContext.Professor.Add(professor);
            _bancoContext.SaveChanges();
            return professor;
        }

        public List<ProfessorModel> GetProfessores(int userId)
        {
            return _bancoContext.Professor.Where(a => a.Escola_id == userId).ToList();
        }

        public ProfessorModel ProfessorById(int id)
        {
            return _bancoContext.Professor.FirstOrDefault(x => x.Id == id);
        }

        public bool Deletar(int id)
        {
            ProfessorModel deletarProfessor = ProfessorById(id);
            if (deletarProfessor == null)
            {
                return false;
            }
            _bancoContext.Professor.Remove(deletarProfessor);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
