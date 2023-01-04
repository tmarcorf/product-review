using MongoDB.Driver;

namespace ProductReview.Repositorio.Interfaces
{
    public interface IContextoBD
    {
        /// <summary>
        /// Obtém a coleção de uma entidade específica.
        /// </summary>
        /// <typeparam name="T">O tipo da coleção.</typeparam>
        /// <param name="nomeDaColecao">O nome da coleção.</param>
        /// <returns>A coleção recuperada do banco de dados.</returns>
        IMongoCollection<T> ObtenhaColecao<T>(string nomeDaColecao);
    }
}
