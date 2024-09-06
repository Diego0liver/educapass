using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace educapass_api.Controllers
{
    [Route("api/classeProfessor")]
    [ApiController]
    public class ClasseProfessorController : ControllerBase
    {
        private readonly IClasseProfessorRepository _classeProfessorRepository;
        public ClasseProfessorController(IClasseProfessorRepository classeProfessorRepository)
        {
            _classeProfessorRepository = classeProfessorRepository;
        }

        [HttpPost]
        public IActionResult PostClaseProfesssor(ClasseProfessorModel classeProfessor)
        {
            try
            {
                var res = _classeProfessorRepository.Adicionar(classeProfessor);
                return Ok(new { message = "Adicionada com sucesso.", res });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro", details = e.Message });
                throw;
            }
        }
        [HttpGet("{professorId}/classes")]
        public IActionResult GetClassesByProfessor(int professorId)
        {
            try
            {
                var classes = _classeProfessorRepository.GetClasseProfessor(professorId);

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
