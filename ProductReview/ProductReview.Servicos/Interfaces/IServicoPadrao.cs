using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Servico.Interfaces
{
    public interface IServicoPadrao<TObjeto> 
        where TObjeto : EntidadePersistente
    {
        /// <summary>
        /// Realiza a consulta de um entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do entidade a ser consultado.</param>
        /// <returns>O entidade encontrado, ou null se não for encontrado.</returns>
        Task<TObjeto> ConsultarPorId(Guid id);

        /// <summary>
        /// Realiza a consulta de entidades que satisfazem uma determinada condição.
        /// </summary>
        /// <param name="condicao">A condição que os entidades devem satisfazer.</param>
        /// <returns>Uma lista de entidades que satisfazem a condição.</returns>
        Task<List<TObjeto>> ConsultarPor(Expression<Func<TObjeto, bool>> condicao);

        /// <summary>
        /// Cadastra um novo entidade no repositório.
        /// </summary>
        /// <param name="entidade">O entidade a ser cadastrado.</param>
        Task Cadastrar(TObjeto entidade);

        /// <summary>
        /// Atualiza um entidade existente no repositório.
        /// </summary>
        /// <param name="entidade">O entidade a ser atualizado.</param>
        /// <returns>O entidade atualizado.</returns>
        Task<TObjeto> Atualizar(TObjeto entidade);

        /// <summary>
        /// Exclui um entidade do repositório.
        /// </summary>
        /// <param name="id">O ID do entidade a ser excluído.</param>
        /// <returns>true se o entidade foi excluído com sucesso, false caso contrário.</returns>
        Task<bool> Excluir(Guid id);
    }
}
