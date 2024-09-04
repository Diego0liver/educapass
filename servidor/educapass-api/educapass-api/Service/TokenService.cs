using educapass_api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace educapass_api.Service
{
    public class TokenService : ITokenService
    {
        private readonly string _chaveKey = "49e2f131-6c35-4e8b-82a5-educa-d4e2246ca493";
        public string GerarTokenAluno(AlunoModel aluno)
        {
            throw new NotImplementedException();
        }

        public string GerarTokenEscola(EscolaModel escola)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chaveKey));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, escola.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, escola.Email),
            new Claim("Escola", escola.Nome),
            new Claim(ClaimTypes.NameIdentifier, escola.Id.ToString())
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
