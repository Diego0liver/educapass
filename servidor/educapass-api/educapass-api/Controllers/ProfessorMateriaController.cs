using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace educapass_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorMateriaController : ControllerBase
    {
        private readonly IProfessorMateriaRepository _professorMateriaRepository;
        public ProfessorMateriaController(IProfessorMateriaRepository professorMateriaRepository)
        {
            _professorMateriaRepository = professorMateriaRepository;
        }

        [HttpPost]
        public IActionResult PostProfesssorMateria(ProfessorMateriaModel professorMateria)
        {
            try
            {
                var res = _professorMateriaRepository.Adicionar(professorMateria);
                return Ok(new { message = "Adicionada com sucesso.", res });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro", details = e.Message });
                throw;
            }
        }
        [HttpGet("{professorId}/materia")]
        public IActionResult GetMateriaByProfessor(int professorId)
        {
            try
            {
                var classes = _professorMateriaRepository.GetMateriaProfessor(professorId);

                if (classes == null || !classes.Any())
                {
                    return NotFound("Nenhuma classe encontrada para o professor.");
                }

                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }
    }
}
