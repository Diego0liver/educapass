using educapass_api.Models;

namespace educapass_api.Service
{
    public interface ITokenService
    {
        string GerarTokenEscola(EscolaModel escola);
        string GerarTokenAluno(AlunoModel aluno);
    }
}
