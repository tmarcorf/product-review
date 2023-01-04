using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Repositorio.Implementacoes
{
    public class RepositorioDeUsuario : Repositorio<Usuario>, IRepositorioDeUsuario
    {
        public RepositorioDeUsuario(IContextoBD contexto) 
            : base(contexto)
        {
        }
    }
}
