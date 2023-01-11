using MongoDB.Driver;

namespace ProductReview.Repositorio.Interfaces
{
    public interface IContextoBD
    {
        string StringDeConexao { get; set; }

        string NomeDoBanco { get; set; }
    }
}
