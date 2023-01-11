using ProductReview.Negocio.Entidades;
using ProductReview.Repositorio.Interfaces;
using ProductReview.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Servico.Implementacoes
{
    public class ServicoDeUsuario : ServicoPadrao<Usuario>, IServicoDeUsuario
    {
        public ServicoDeUsuario(IRepositorio<Usuario> repositorio) 
            : base(repositorio)
        {
        }
    }
}
