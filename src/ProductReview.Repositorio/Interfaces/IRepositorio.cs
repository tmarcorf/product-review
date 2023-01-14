using ProductReview.Negocio.Entidades;
using System.Linq.Expressions;

namespace ProductReview.Repositorio.Interfaces
{
    public interface IRepositorio<T> where T : EntidadePersistente
    {
        /// <summary>
        /// Realiza a consulta de uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser consultada.</param>
        /// <returns>A entidade encontrada, ou null se não for encontrada.</returns>
        Task<T> ConsultarPorId(Guid id);

        /// <summary>
        /// Realiza a consulta de entidades que satisfazem uma determinada condição.
        /// </summary>
        /// <param name="condicao">A condição que as entidades devem satisfazer.</param>
        /// <returns>Uma lista de entidades que satisfazem a condição.</returns>
        Task<List<T>> ConsultarPor(Expression<Func<T, bool>> condicao);

        /// <summary>
        /// Cadastra uma nova entidade no repositório.
        /// </summary>
        /// <param name="entidade">A entidade a ser cadastrada.</param>
        Task Cadastrar(T entidade);

        /// <summary>
        /// Atualiza uma entidade existente no repositório.
        /// </summary>
        /// <param name="entidade">A entidade a ser atualizada.</param>
        /// <returns>A entidade atualizada.</returns>
        Task<T> Atualizar(T entidade);

        /// <summary>
        /// Exclui uma entidade do repositório.
        /// </summary>
        /// <param name="id">O ID da entidade a ser excluída.</param>
        /// <returns>true se a entidade foi excluída com sucesso, false caso contrário.</returns>
        Task<bool> Excluir(Guid id);

        /// <summary>
        /// Verifica se uma entidade existe no repositório.
        /// </summary>
        /// <param name="id">O identificador da entidade.</param>
        /// <returns>True se a entidade existe, false caso contrário.</returns>
        Task<bool> Existe(Guid id);
    }
}
