using MongoDB.Driver;
using ProductReview.Repositorio.Interfaces;

namespace ProductReview.Repositorio.Contexto
{
    public class ContextoBD : IContextoBD
    {
        public string StringDeConexao { get; set; }

        public string NomeDoBanco { get; set; }
    }
}
