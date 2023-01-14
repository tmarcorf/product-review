using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Negocio.Conversores;
using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using ProductReview.Servico.Interfaces;

namespace ProductReview.API.Controllers
{
    [Route("api/avaliacao")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IServicoDeAvaliacao _servicoDeAvaliacao;
        private readonly IServicoDeProduto _servicoDeProduto;
        private readonly IServicoDeUsuario _servicoDeUsuario;

        public AvaliacaoController(IServicoDeAvaliacao servicoDeAvaliacao, IServicoDeProduto servicoDeProduto, IServicoDeUsuario servicoDeUsuario)
        {
            _servicoDeAvaliacao = servicoDeAvaliacao;
            _servicoDeProduto = servicoDeProduto;
            _servicoDeUsuario = servicoDeUsuario;
        }

        [HttpGet("consulta/id")]
        public async Task<IActionResult> ConsultarPorId(string idAvaliacao)
        {
            try
            {
                Guid idGuid;
                Guid.TryParse(idAvaliacao, out idGuid);

                var avaliacao = await _servicoDeAvaliacao.ConsultarPorId(idGuid);

                if (avaliacao is null)
                {
                    return NotFound("A avaliação não foi encontrada.");
                }

                var produto = await _servicoDeProduto.ConsultarPorId(avaliacao.IdDoProduto);
                var usuario = await _servicoDeUsuario.ConsultarPorId(avaliacao.IdDoUsuario);

                var dtoAvaliacao = ConversorDeAvaliacao.Instancia.Converta(avaliacao, produto, usuario);

                return Ok(dtoAvaliacao);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("consulta/produto")]
        public async Task<IActionResult> ConsultarPorProduto(string idProduto)
        {
            try
            {
                Guid idGuidProduto;
                Guid.TryParse(idProduto, out idGuidProduto);

                var produtoExiste = await _servicoDeProduto.Existe(idGuidProduto);

                if (!produtoExiste)
                {
                    return NotFound("O produto informado não existe.");
                }

                var listaDeUsuarios = new List<Usuario>();
                var listaDeAvaliacoes = await _servicoDeAvaliacao.ConsultarPor(x => x.IdDoProduto == idGuidProduto);
                var produto = await _servicoDeProduto.ConsultarPorId(idGuidProduto);

                listaDeAvaliacoes.ForEach(avaliacao =>
                {
                    listaDeUsuarios.Add(_servicoDeUsuario.ConsultarPorId(avaliacao.IdDoUsuario).Result);
                });

                var listaDtoAvaliacao = ConversorDeAvaliacao.Instancia.ConvertaComMesmoProduto(listaDeAvaliacoes, listaDeUsuarios, produto);

                return Ok(listaDtoAvaliacao);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("consulta/usuario")]
        public async Task<IActionResult> ConsultarPorUsuario(string idUsuario)
        {
            try
            {
                Guid idGuidUsuario;
                Guid.TryParse(idUsuario, out idGuidUsuario);

                var usuarioExiste = await _servicoDeUsuario.Existe(idGuidUsuario);

                if (!usuarioExiste)
                {
                    return NotFound("O usuário informado não existe.");
                }

                var listaDeProdutos = new List<Produto>();
                var listaDeAvaliacoes = await _servicoDeAvaliacao.ConsultarPor(x => x.IdDoUsuario == idGuidUsuario);
                var usuario = await _servicoDeUsuario.ConsultarPorId(idGuidUsuario);

                listaDeAvaliacoes.ForEach(avaliacao =>
                {
                    listaDeProdutos.Add(_servicoDeProduto.ConsultarPorId(avaliacao.IdDoProduto).Result);
                });

                var listaDtoAvaliacao = ConversorDeAvaliacao.Instancia.ConvertaComMesmoUsuario(listaDeAvaliacoes, listaDeProdutos, usuario);

                return Ok(listaDtoAvaliacao);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar(DtoAvaliacaoInsercaoAtualizacao dtoAvaliacao)
        {
            try
            {
                dtoAvaliacao.Id = Guid.NewGuid().ToString();
                var avaliacao = ConversorDeAvaliacao.Instancia.ConvertaParaInsercaoAtualizacao(dtoAvaliacao);

                await _servicoDeAvaliacao.Cadastrar(avaliacao);

                string mensagem = string.Format("Cadastro realizado com sucesso. Id: {0}", dtoAvaliacao.Id);

                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
