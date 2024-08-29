using educapass_api.Db;
using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace educapass_api.Controllers
{
    [Route("api/escola")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaRepository _escolaRepository;
        public EscolaController(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }
        // GET: api/<EscolaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EscolaController>/5
        [Authorize]
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
                        var token = TokenJWT(emailEscola);
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
        private string TokenJWT(EscolaModel escola)
        {
            string chaveKey = "49e2f131-6c35-4e8b-82a5-educa-d4e2246ca493";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveKey));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, escola.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, escola.Email),
                new Claim("NomeEscola", escola.Nome),
            };
            var token = new JwtSecurityToken(
                issuer: "educa_pass",
                audience: "educapass_api",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credencial
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
