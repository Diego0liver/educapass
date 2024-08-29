using educapass_api.Db;
using educapass_api.Migrations;
using educapass_api.Models;

namespace educapass_api.Repository
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly BancoContext _bancoContext;
        public ClaseRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ClaseModel Adicionar(ClaseModel clase)
        {
            _bancoContext.Clase.Add(clase);
            _bancoContext.SaveChanges();
            return clase;
        }

        public ClaseModel ClaseById(int id)
        {
            return _bancoContext.Clase.FirstOrDefault(x => x.Id == id);
        }

        public List<ClaseModel> GetClases()
        {
            return _bancoContext.Clase.ToList();
        }

        public bool Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
