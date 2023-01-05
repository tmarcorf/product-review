using ProductReview.Negocio.Entidades;
using System.Linq.Expressions;

namespace ProductReview.Servico.Interfaces
{
    public interface IServicoDeProduto
    {
        /// <summary>
        /// Realiza a consulta de um produto pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser consultado.</param>
        /// <returns>O produto encontrado, ou null se não for encontrado.</returns>
        Task<Produto> ConsultarPorId(Guid id);

        /// <summary>
        /// Realiza a consulta de produtos que satisfazem uma determinada condição.
        /// </summary>
        /// <param name="condicao">A condição que os produtos devem satisfazer.</param>
        /// <returns>Uma lista de produtos que satisfazem a condição.</returns>
        Task<List<Produto>> ConsultarPor(Expression<Func<Produto, bool>> condicao);

        /// <summary>
        /// Cadastra um novo produto no repositório.
        /// </summary>
        /// <param name="entidade">O produto a ser cadastrado.</param>
        Task Cadastrar(Produto entidade);

        /// <summary>
        /// Atualiza um produto existente no repositório.
        /// </summary>
        /// <param name="entidade">O produto a ser atualizado.</param>
        /// <returns>O produto atualizado.</returns>
        Task<Produto> Atualizar(Produto entidade);

        /// <summary>
        /// Exclui um produto do repositório.
        /// </summary>
        /// <param name="id">O ID do produto a ser excluído.</param>
        /// <returns>true se o produto foi excluído com sucesso, false caso contrário.</returns>
        Task<bool> Excluir(Guid id);
    }
}
