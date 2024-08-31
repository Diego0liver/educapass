using educapass_api.Models;

namespace educapass_api.Repository
{
    public interface IAlunoRepository
    {
        List<AlunoModel> GetAlunos();
        AlunoModel AlunoById(int id);
        AlunoModel Adicionar(AlunoModel aluno);
        bool Deletar(int id);
    }
}
