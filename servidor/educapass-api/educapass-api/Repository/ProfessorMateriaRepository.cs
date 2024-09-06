using educapass_api.Db;
using educapass_api.Migrations;
using educapass_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educapass_api.Repository
{
    public class ProfessorMateriaRepository : IProfessorMateriaRepository
    {
        private readonly BancoContext _bancoContext;
        public ProfessorMateriaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ProfessorMateriaModel Adicionar(ProfessorMateriaModel professorMateriaModel)
        {
            _bancoContext.ProfessorMateria.Add(professorMateriaModel);
            _bancoContext.SaveChanges();
            return professorMateriaModel;
        }

        public List<ProfessorMateriaModel> GetMateriaProfessor(int professorId)
        {
            return _bancoContext.ProfessorMateria
                .Where(a => a.Professor_id == professorId)
                .Include(i => i.Materia)
                .ToList();
        }

        public ProfessorMateriaModel MateriaProfessorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
