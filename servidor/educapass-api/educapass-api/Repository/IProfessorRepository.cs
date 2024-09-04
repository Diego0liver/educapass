using educapass_api.Models;

namespace educapass_api.Repository
{
    public interface IProfessorRepository
    {
        List<ProfessorModel> GetProfessores(int userId);
        ProfessorModel ProfessorById(int id);
        ProfessorModel Adicionar(ProfessorModel professor);
        bool Deletar(int id);
    }
}
