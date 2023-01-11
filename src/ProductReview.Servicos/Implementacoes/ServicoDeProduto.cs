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
    }
}
