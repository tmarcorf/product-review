using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Repositorio.Implementacoes
{
    public class RepositorioDeProduto : Repositorio<Produto>, IRepositorioDeProduto
    {
        public RepositorioDeProduto(IContextoBD contexto) 
            : base(contexto)
        {
        }

        public override Task<Produto> ConsultarPorId(Guid id)
        {
            return base.ConsultarPorId(id);
        }

        public override Task<List<Produto>> ConsultarPor(Expression<Func<Produto, bool>> condicao)
        {
            return base.ConsultarPor(condicao);
        }

        public override Task Cadastrar(Produto entidade)
        {
            return base.Cadastrar(entidade);
        }

        public override Task<Produto> Atualizar(Produto entidade)
        {
            return base.Atualizar(entidade);
        }

        public override Task<bool> Excluir(Guid id)
        {
            return base.Excluir(id);
        }
    }
}
