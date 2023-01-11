using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Implementacoes;
using ProductReview.Repositorio.Interfaces;
using ProductReview.Servico.Interfaces;
using System.Linq.Expressions;

namespace ProductReview.Servico.Implementacoes
{
    public abstract class ServicoPadrao<TObjeto> : IServicoPadrao<TObjeto>
        where TObjeto : EntidadePersistente
        
    {
        protected readonly IRepositorio<TObjeto> _repositorio;

        public ServicoPadrao(IRepositorio<TObjeto> repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Realiza a consulta de um entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do entidade a ser consultado.</param>
        /// <returns>O entidade encontrado, ou null se não for encontrado.</returns>
        public virtual async Task<TObjeto> ConsultarPorId(Guid id)
        {
            return await _repositorio.ConsultarPorId(id);
        }

        /// <summary>
        /// Realiza a consulta de entidades que satisfazem uma determinada condição.
        /// </summary>
        /// <param name="condicao">A condição que os entidades devem satisfazer.</param>
        /// <returns>Uma lista de entidades que satisfazem a condição.</returns>
        public virtual async Task<List<TObjeto>> ConsultarPor(Expression<Func<TObjeto, bool>> condicao)
        {
            return await _repositorio.ConsultarPor(condicao);
        }

        /// <summary>
        /// Cadastra um novo entidade no repositório.
        /// </summary>
        /// <param name="entidade">O entidade a ser cadastrado.</param>
        public virtual async Task Cadastrar(TObjeto entidade)
        {
            await _repositorio.Cadastrar(entidade);
        }

        /// <summary>
        /// Atualiza um entidade existente no repositório.
        /// </summary>
        /// <param name="entidade">O entidade a ser atualizado.</param>
        /// <returns>O entidade atualizado.</returns>
        public virtual async Task<TObjeto> Atualizar(TObjeto entidade)
        {
            return await _repositorio.Atualizar(entidade);
        }

        /// <summary>
        /// Exclui um entidade do repositório.
        /// </summary>
        /// <param name="id">O ID do entidade a ser excluído.</param>
        /// <returns>true se o entidade foi excluído com sucesso, false caso contrário.</returns>
        public virtual async Task<bool> Excluir(Guid id)
        {
            return await _repositorio.Excluir(id);
        }
    }
}
