using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;
using ProductReview.Servico.Interfaces;
using System.Linq.Expressions;

namespace ProductReview.Servico.Implementacoes
{
    public class ServicoDeProduto : ServicoPadrao<Produto>, IServicoDeProduto
    {
        public ServicoDeProduto(IRepositorioDeProduto repositorio)
            : base(repositorio)
        {
        }

        /// <summary>
        /// Recupera um produto através do seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do produto a ser recuperado.</param>
        /// <returns>O produto com o identificador único especificado.</returns>
        public override async Task<Produto> ConsultarPorId(Guid id)
        {
            return await base.ConsultarPorId(id);
        }

        /// <summary>
        /// Recupera uma lista de produtos que correspondem à condição especificada.
        /// </summary>
        /// <param name="condicao">A condição para filtrar os produtos.</param>
        /// <returns>Uma lista de produtos que correspondem à condição especificada.</returns>
        public override async Task<List<Produto>> ConsultarPor(Expression<Func<Produto, bool>> condicao)
        {
            return await base.ConsultarPor(condicao);
        }

        /// <summary>
        /// Registra um novo produto.
        /// </summary>
        /// <param name="entidade">O produto a ser registrado.</param>
        public override async Task Cadastrar(Produto entidade)
        {
            await base.Cadastrar(entidade);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="entidade">O produto a ser atualizado.</param>
        /// <returns>O produto atualizado.</returns>
        public override async Task<Produto> Atualizar(Produto entidade)
        {
            return await base.Atualizar(entidade);
        }

        /// <summary>
        /// Exclui um produto existente através de seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do produto a ser excluído.</param>
        /// <returns>Retorna 'true' se a exclusão for bem-sucedida e 'false' caso contrário.</returns>
        public override async Task<bool> Excluir(Guid id)
        {
            return await base.Excluir(id);
        }
    }
}
