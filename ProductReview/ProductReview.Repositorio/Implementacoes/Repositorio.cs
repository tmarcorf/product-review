using MongoDB.Driver;
using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;
using System.Linq.Expressions;

namespace ProductReview.Repositorio.Implementacoes
{
    public class Repositorio<T> : IRepositorio<T> 
        where T : EntidadePersistente
    {
        private readonly IMongoCollection<T> _colecao;

        public Repositorio(IContextoBD contexto)
        {
            _colecao = contexto.ObtenhaColecao<T>(typeof(T).Name);
        }

        /// <summary>
        /// Realiza a consulta de uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser consultada.</param>
        /// <returns>A entidade encontrada, ou null se não for encontrada.</returns>
        public async Task<T> ConsultarPorId(Guid id)
        {
            var entidade = await _colecao.FindAsync(x => x.Id == id);

            return entidade.ToList().First();
        }

        /// <summary>
        /// Realiza a consulta de entidades que satisfazem uma determinada condição.
        /// </summary>
        /// <param name="condicao">A condição que as entidades devem satisfazer.</param>
        /// <returns>Uma lista de entidades que satisfazem a condição.</returns>
        public async Task<List<T>> ConsultarPor(Expression<Func<T, bool>> condicao)
        {
            var entidades = await _colecao.FindAsync(condicao);

            return entidades.ToList();
        }

        /// <summary>
        /// Cadastra uma nova entidade no repositório.
        /// </summary>
        /// <param name="entidade">A entidade a ser cadastrada.</param>
        public async Task Cadastrar(T entidade)
        {
            await _colecao.InsertOneAsync(entidade);
        }

        /// <summary>
        /// Atualiza uma entidade existente no repositório.
        /// </summary>
        /// <param name="entidade">A entidade a ser atualizada.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<T> Atualizar(T entidade)
        {
            var entidadeExiste = _colecao.AsQueryable().Any(x => x.Id == entidade.Id);

            if (entidadeExiste)
            {
                return await _colecao.FindOneAndReplaceAsync(x => x.Id == entidade.Id, entidade);
            }

            return default;
        }

        /// <summary>
        /// Exclui uma entidade do repositório.
        /// </summary>
        /// <param name="id">O ID da entidade a ser excluída.</param>
        /// <returns>true se a entidade foi excluída com sucesso, false caso contrário.</returns>
        public async Task<bool> Excluir(Guid id)
        {
            var entidade = await ConsultarPorId(id);

            if (entidade != null)
            {
                var resultadoExclusao = await _colecao.DeleteOneAsync(x => x.Id == id);

                return (resultadoExclusao.IsAcknowledged && resultadoExclusao.DeletedCount > 0);
            }

            return false;
        }
    }
}
