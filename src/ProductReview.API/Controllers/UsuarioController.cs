using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
using ProductReview.Negocio.Conversores;
using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using ProductReview.Servico.Interfaces;

namespace ProductReview.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoDeUsuario _servico;

        public UsuarioController(IServicoDeUsuario servico)
        {
            _servico = servico;
        }

        [HttpGet("consulta/id")]
        public async Task<IActionResult> ConsultarPorId(string idUsuario)
        {
            try
            {
                Guid idGuid;
                Guid.TryParse(idUsuario, out idGuid);

                var usuario = await _servico.ConsultarPorId(idGuid);

                if (usuario is null)
                {
                    return NotFound("O usuário não foi encontrado.");
                }

                var dtoUsuario = ConversorDeUsuario.Instancia.Converta(usuario);

                return Ok(dtoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("consulta/nome")]
        public async Task<IActionResult> ConsultarPorNome(string nomeDoUsuario)
        {
            try
            {
                var listaDeUsuarios = await _servico.ConsultarPor(x => x.PrimeiroNome.Contains(nomeDoUsuario) ||
                                                                       x.UltimoNome.Contains(nomeDoUsuario));

                if (!listaDeUsuarios.Any())
                {
                    return NotFound("Nenhum registro encontrado.");
                }

                var listaDeDtoUsuario = ConversorDeUsuario.Instancia.Converta(listaDeUsuarios);

                return Ok(listaDeDtoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar(DtoUsuario dtoUsuario)
        {
            try
            {
                dtoUsuario.Id = Guid.NewGuid().ToString();
                var usuario = ConversorDeUsuario.Instancia.Converta(dtoUsuario);

                await _servico.Cadastrar(usuario);

                string mensagem = string.Format("Cadastro realizado com sucesso. Id: {0}", dtoUsuario.Id);

                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("atualizacao")]
        public async Task<IActionResult> Atualizar(DtoUsuario dtoUsuario)
        {
            try
            {
                var usuario = ConversorDeUsuario.Instancia.Converta(dtoUsuario);
                var usuarioAtualizado = await _servico.Atualizar(usuario);

                if (usuarioAtualizado is null)
                {
                    return NotFound("O usuário " + dtoUsuario.PrimeiroNome + " " + dtoUsuario.UltimoNome + " não foi encontrado.");
                }

                var dtoUsuarioAtualizado = ConversorDeUsuario.Instancia.Converta(await _servico.ConsultarPorId(usuarioAtualizado.Id));

                var retorno = new
                {
                    mensagem = "O usuário foi atualizado.",
                    usuario = dtoUsuarioAtualizado
                };

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("exclusao")]
        public async Task<IActionResult> Excluir(string idUsuario)
        {
            try
            {
                Guid idGuid;
                Guid.TryParse(idUsuario, out idGuid);

                var retornoExclusao = await _servico.Excluir(idGuid);

                if (!retornoExclusao)
                {
                    return NotFound("O usuário não foi excluído.");
                }

                var retorno = new
                {
                    sucesso = retornoExclusao,
                    mensagem = "O usuário com o identificador " + idUsuario + " foi excluído."
                };

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
