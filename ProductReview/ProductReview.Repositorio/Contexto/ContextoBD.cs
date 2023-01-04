using MongoDB.Driver;
using ProductReview.Repositorio.Interfaces;

namespace ProductReview.Repositorio.Contexto
{
    public class ContextoBD : IContextoBD
    {
        private readonly IMongoDatabase _bancoDeDados;
        private const string NOME_DO_BANCO = "ProductReviewDatabase";

        /// <summary>
        /// O construtor da classe.
        /// </summary>
        /// <param name="stringDeConexao">A string de conexão.</param>
        public ContextoBD(string stringDeConexao)
        {
            var client = new MongoClient(stringDeConexao);
            _bancoDeDados = client.GetDatabase(NOME_DO_BANCO);
        }

        /// <summary>
        /// Obtém a coleção de uma entidade específica.
        /// </summary>
        /// <typeparam name="T">O tipo da coleção.</typeparam>
        /// <param name="nomeDaColecao">O nome da coleção.</param>
        /// <returns>A coleção recuperada do banco de dados.</returns>
        public IMongoCollection<T> ObtenhaColecao<T>(string nomeDaColecao)
        {
            return _bancoDeDados.GetCollection<T>(nomeDaColecao);
        }
    }
}
