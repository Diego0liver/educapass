using educapass_api.Models;
using educapass_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetAlunos()
        {
            var alunosAll = _alunoRepository.GetAlunos();

            return Ok(alunosAll);
        }

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
    }
}
