using educapass_api.Db;
using educapass_api.Models;
using educapass_api.Repository;
using educapass_api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace educapass_api.Controllers
{
    [Route("api/escola")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly ITokenService _tokenService;
        public EscolaController(IEscolaRepository escolaRepository, ITokenService tokenService)
        {
            _escolaRepository = escolaRepository;
            _tokenService = tokenService;
        }
        // GET: api/<EscolaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EscolaController>/5
        [HttpGet("{id}")]
        public IActionResult EscolaById(int id)
        {
            var res = _escolaRepository.EscolarId(id);
            if(res != null)
            {
                return Ok(new { message = "Escola econtrada.", res });
            }
            return StatusCode(500, new { message = "Escola nao encontrada" });
        }

      
        // PUT api/<EscolaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EscolaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //Action de logar a escola
        [HttpPost]
        public IActionResult LoginEscola([FromBody] LoginEscolaModel loginEscola)
        {
            try
            {
                EscolaModel emailEscola = _escolaRepository.BuscarLoginEmail(loginEscola.Email);
                if(emailEscola != null)
                {
                    if (emailEscola.SenhaValida(loginEscola.Senha))
                    {
                        var token = _tokenService.GerarTokenEscola(emailEscola);
                        return Ok(new { token });
                    }
                }
                return BadRequest(new { mensagem = "Nao autorizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { err = "Erro: Nao autorizado" });
            }
        }
    }
}
