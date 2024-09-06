using educapass_api.Db;
using educapass_api.Migrations;
using educapass_api.Models;

namespace educapass_api.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly BancoContext _bancoContext;
        public MateriaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public MateriaModel Adicionar(MateriaModel materia)
        {
            _bancoContext.Materia.Add(materia);
            _bancoContext.SaveChanges();
            return materia;
        }

        public List<MateriaModel> GetMaterias(int userId)
        {
            return _bancoContext.Materia.Where(a => a.Escola_id == userId).ToList();
        }

        public MateriaModel MateriaById(int id)
        {
            return _bancoContext.Materia.FirstOrDefault(x => x.Id == id);
        }

        public bool Deletar(int id)
        {
            MateriaModel deletarMateria = MateriaById(id);
            if (deletarMateria == null)
            {
                return false;
            }
            try
            {
                _bancoContext.Materia.Remove(deletarMateria);
                _bancoContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
