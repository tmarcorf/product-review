using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
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

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Usuario usuario)
        {
            try
            {
                await _servico.Cadastrar(usuario);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
