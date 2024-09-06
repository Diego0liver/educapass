using educapass_api.Models;

namespace educapass_api.Repository
{
    public interface IClasseProfessorRepository
    {
        ClasseProfessorModel Adicionar(ClasseProfessorModel classeProfessor);
        ClasseProfessorModel ClasseProfessorId(int id);
        List<ClasseProfessorModel> GetClasseProfessor(int professorId);
    }
}
