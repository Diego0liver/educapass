using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace educapass_api.Controllers
{
    [Route("api/materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _materiaRepository;
        public MateriaController(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostMateria(MateriaModel materia)
        {
            try
            {
                var res = _materiaRepository.Adicionar(materia);
                return Ok(new { message = "Materia adicionada com sucesso.", res });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro", details = e.Message });
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetMaterias()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized($"Token inválido ou não contém o claim necessário.");
            }

            var userId = int.Parse(userIdClaim.Value);
            var materiaAll = _materiaRepository.GetMaterias(userId);

            return Ok(materiaAll);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteMateria(int id)
        {
            bool res = _materiaRepository.Deletar(id);
            if (!res)
            {
                return NotFound(new { message = "Materia não encontrada." });
            }
            return Ok(new { message = "Materia deletada com sucesso.", res });
        }
    }
}
