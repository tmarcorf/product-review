using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;

namespace ProductReview.Repositorio.Implementacoes
{
    public class RepositorioDeAvaliacao : Repositorio<Avaliacao>, IRepositorioDeAvaliacao
    {
        public RepositorioDeAvaliacao(IContextoBD contexto) 
            : base(contexto)
        {
        }
    }
}
