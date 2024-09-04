using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace educapass_api.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostAluno([FromBody] AlunoCreateDto createDto)
        {
            try
            {
                if (createDto == null)
                {
                    return BadRequest("O DTO de criação é obrigatório.");
                }
                var aluno = new AlunoModel
                {
                    Nome = createDto.Nome,
                    Inscricao = createDto.Inscricao,
                    Email = createDto.Email,
                    Senha = createDto.Senha,
                    Telefone = createDto.Telefone,
                    Cpf = createDto.Cpf,
                    DataNascimento = createDto.DataNascimento,
                    Responsavel = createDto.Responsavel,
                    ContatoResponsavel = createDto.ContatoResponsavel,
                    NumeroChamada = createDto.NumeroChamada,
                    TotalFalta = createDto.TotalFalta,
                    Escola_id = createDto.Escola_id,
                    Clase_id = createDto.Clase_id
                };
                var res = _alunoRepository.Adicionar(aluno);
                return Ok(new { message = "Aluno adicionada com sucesso.", res });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro", details = e.Message });
                throw;
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            bool res = _alunoRepository.Deletar(id);
            if (!res)
            {
                return NotFound(new { message = "Aluno não encontrada." });
            }
            return Ok(new { message = "Aluno deletada com sucesso.", res });
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult AlunoById(int id)
        {
            var res = _alunoRepository.AlunoById(id);
            if (res != null)
            {
                return Ok(new { message = "Aluno econtrada.", res });
            }
            return StatusCode(500, new { message = "Aluno nao encontrada" });
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAlunos()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            
            if (userIdClaim == null)
            {
                return Unauthorized($"Token inválido ou não contém o claim necessário.");
            }

            var userId = int.Parse(userIdClaim.Value);

            var alunosAll = _alunoRepository.GetAlunos(userId);

            return Ok(alunosAll);
        }
    }
}
