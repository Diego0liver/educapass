using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace educapass_api.Controllers
{
    [Route("api/professor")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostProfessor(ProfessorModel professor)
        {
            try
            {
                var res = _professorRepository.Adicionar(professor);
                return Ok(new { message = "Professor adicionada com sucesso.", res });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro", details = e.Message });
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetProfessores()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized($"Token inválido ou não contém o claim necessário.");
            }

            var userId = int.Parse(userIdClaim.Value);

            var professoresAll = _professorRepository.GetProfessores(userId);

            return Ok(professoresAll);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult ProfessorById(int id)
        {
            var res = _professorRepository.ProfessorById(id);
            if (res != null)
            {
                return Ok(new { message = "Professor econtrada.", res });
            }
            return StatusCode(500, new { message = "Professor nao encontrada" });
        }
    }
}
