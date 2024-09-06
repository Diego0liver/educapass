using educapass_api.Models;

namespace educapass_api.Repository
{
    public interface IMateriaRepository
    {
        List<MateriaModel> GetMaterias(int userId);
        MateriaModel MateriaById(int id);
        MateriaModel Adicionar(MateriaModel materia);
        bool Deletar(int id);
    }
}
