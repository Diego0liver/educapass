using educapass_api.Models;

namespace educapass_api.Repository
{
    public interface IEscolaRepository
    {
        EscolaModel Adicionar(EscolaModel escola);
        EscolaModel EscolarId(int id);
        EscolaModel BuscarLoginEmail(string email);
    }
}
