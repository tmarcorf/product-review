using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;
using ProductReview.Servico.Interfaces;
using System.Linq.Expressions;

namespace ProductReview.Servico.Implementacoes
{
    public class ServicoDeProduto : IServicoDeProduto
    {
        private readonly IRepositorioDeProduto _repositorioDeProduto;

        public ServicoDeProduto(IRepositorioDeProduto repositorioDeProduto)
        {
            _repositorioDeProduto = repositorioDeProduto;
        }

        /// <summary>
        /// Realiza a consulta de um produto pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser consultado.</param>
        /// <returns>O produto encontrado, ou null se não for encontrado.</returns>
        public async Task<Produto> ConsultarPorId(Guid id)
        {
            return await _repositorioDeProduto.ConsultarPorId(id);
        }

        /// <summary>
        /// Realiza a consulta de produtos que satisfazem uma determinada condição.
        /// </summary>
        /// <param name="condicao">A condição que os produtos devem satisfazer.</param>
        /// <returns>Uma lista de produtos que satisfazem a condição.</returns>
        public async Task<List<Produto>> ConsultarPor(Expression<Func<Produto, bool>> condicao)
        {
            return await _repositorioDeProduto.ConsultarPor(condicao);
        }

        /// <summary>
        /// Cadastra um novo produto no repositório.
        /// </summary>
        /// <param name="produto">O produto a ser cadastrado.</param>
        public async Task Cadastrar(Produto produto)
        {
            await _repositorioDeProduto.Cadastrar(produto);
        }

        /// <summary>
        /// Atualiza um produto existente no repositório.
        /// </summary>
        /// <param name="produto">O produto a ser atualizado.</param>
        /// <returns>O produto atualizado.</returns>
        public async Task<Produto> Atualizar(Produto produto)
        {
            return await _repositorioDeProduto.Atualizar(produto);
        }

        /// <summary>
        /// Exclui um produto do repositório.
        /// </summary>
        /// <param name="id">O ID do produto a ser excluído.</param>
        /// <returns>true se o produto foi excluído com sucesso, false caso contrário.</returns>
        public async Task<bool> Excluir(Guid id)
        {
            return await _repositorioDeProduto.Excluir(id);
        }
    }
}
