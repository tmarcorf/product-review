using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Repositorio.Implementacoes
{
    internal class RepositorioDeAvaliacao : Repositorio<Avaliacao>, IRepositorioDeAvaliacao
    {
        public RepositorioDeAvaliacao(IContextoBD contexto) 
            : base(contexto)
        {
        }
    }
}
