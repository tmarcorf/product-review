﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Negocio.Conversores;
using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using ProductReview.Servico.Interfaces;
using System.Linq.Expressions;

namespace ProductReview.API.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IServicoDeProduto _servico;

        public ProdutoController(IServicoDeProduto servico)
        {
            _servico = servico;
        }

        [HttpGet("id")]
        public async Task<IActionResult> ConsultarPorId(string idProduto)
        {
            try
            {
                Guid idGuid;
                Guid.TryParse(idProduto, out idGuid);

                var produto = await _servico.ConsultarPorId(idGuid);

                if (produto is null)
                {
                    return NotFound("O produto não foi encontrado.");
                }

                var dtoProduto = ConversorDeProduto.Instancia.Converta(produto);

                return Ok(dtoProduto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);                
            }
        }

        [HttpGet("nome")]
        public async Task<IActionResult> ConsultarPorNome(string nomeDoProduto)
        {
            try
            {
                var listaDeProdutos = await _servico.ConsultarPor(x => x.Nome.Contains(nomeDoProduto));

                if (!listaDeProdutos.Any())
                {
                    return NotFound("Nenhum registro encontrado.");
                }

                var listaDeDtoProdutos = ConversorDeProduto.Instancia.Converta(listaDeProdutos);

                return Ok(listaDeDtoProdutos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(DtoProduto dtoProduto)
        {
            try
            {
                dtoProduto.Id = Guid.NewGuid().ToString();
                var produto = ConversorDeProduto.Instancia.Converta(dtoProduto);

                await _servico.Cadastrar(produto);

                string mensagem = string.Format("Cadastro realizado com sucesso. Id: {0}", dtoProduto.Id);

                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(DtoProduto dtoProduto)
        {
            try
            {
                var produto = ConversorDeProduto.Instancia.Converta(dtoProduto);
                var produtoAtualizado = await _servico.Atualizar(produto);

                if (produtoAtualizado is null)
                {
                    return NotFound("O produto " + dtoProduto.Nome + " não foi encontrado.");
                }

                var retorno = new
                {
                    mensagem = "O produto foi atualizado.",
                    produto = produtoAtualizado
                };

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(string idProduto)
        {
            try
            {
                Guid idGuid;
                Guid.TryParse(idProduto, out idGuid);

                var retorno = await _servico.Excluir(idGuid);

                if (!retorno)
                {
                    return NotFound("Produto não foi excluído");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
