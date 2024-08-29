using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetClases()
        {
            var clasesAll = _claseRepository.GetClases();

            return Ok(clasesAll);
        }
    }
}
