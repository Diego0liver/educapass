using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace educapass_api.Controllers
{
    [Route("api/clases")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IClaseRepository _claseRepository;
        public ClaseController(IClaseRepository claseRepository)
        {
            _claseRepository = claseRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostClase(ClaseModel clase)
        {
            try
            {
                var res = _claseRepository.Adicionar(clase);
                return Ok(new { message = "Clase adicionada com sucesso.", res });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro", details = e.Message });
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetClases()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized($"Token inválido ou não contém o claim necessário.");
            }

            var userId = int.Parse(userIdClaim.Value);
            var clasesAll = _claseRepository.GetClases(userId);

            return Ok(clasesAll);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteClases(int id)
        {
            bool res = _claseRepository.Deletar(id);
            if (!res)
            {
                return NotFound(new { message = "Clase não encontrada." });
            }
            return Ok(new { message = "Clase deletada com sucesso.", res });
        }
    }
}
