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
    public class ServicoDeAvaliacao : ServicoPadrao<Avaliacao>, IServicoDeAvaliacao
    {
        public ServicoDeAvaliacao(IRepositorioDeAvaliacao repositorio) 
            : base(repositorio)
        {
        }
    }
}
