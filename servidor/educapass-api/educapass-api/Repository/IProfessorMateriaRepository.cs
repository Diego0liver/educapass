using educapass_api.Models;

namespace educapass_api.Repository
{
    public interface IProfessorMateriaRepository
    {
        ProfessorMateriaModel Adicionar(ProfessorMateriaModel professorMateriaModel);
        ProfessorMateriaModel MateriaProfessorId(int id);
        List<ProfessorMateriaModel> GetMateriaProfessor(int professorId);
    }
}
