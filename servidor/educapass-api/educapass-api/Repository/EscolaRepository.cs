using educapass_api.Db;
using educapass_api.Models;

namespace educapass_api.Repository
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly BancoContext _bancoContext;
        public EscolaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public EscolaModel Adicionar(EscolaModel escola)
        {
            _bancoContext.Escola.Add(escola);
            _bancoContext.SaveChanges();
            return escola;
        }

        public EscolaModel BuscarLoginEmail(string email)
        {
            return _bancoContext.Escola.FirstOrDefault(x => x.Email == email);
        }

        public EscolaModel EscolarId(int id)
        {
            return _bancoContext.Escola.FirstOrDefault(x => x.Id == id);
        }
    }
}
