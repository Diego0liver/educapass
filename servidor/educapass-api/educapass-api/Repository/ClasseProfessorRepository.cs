using educapass_api.Db;
using educapass_api.Migrations;
using educapass_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educapass_api.Repository
{
    public class ClasseProfessorRepository : IClasseProfessorRepository
    {
        private readonly BancoContext _bancoContext;
        public ClasseProfessorRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ClasseProfessorModel Adicionar(ClasseProfessorModel classeProfessor)
        {
            _bancoContext.ClasseProfessor.Add(classeProfessor);
            _bancoContext.SaveChanges();
            return classeProfessor;
        }

        public ClasseProfessorModel ClasseProfessorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClasseProfessorModel> GetClasseProfessor(int professorId)
        {
            return _bancoContext.ClasseProfessor
                .Where(a => a.Professor_id == professorId)
                .Include(i => i.Clase)
                .ToList();
        }
    }
}
