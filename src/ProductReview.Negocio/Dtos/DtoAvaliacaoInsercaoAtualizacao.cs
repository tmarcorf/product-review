using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Dtos
{
    public class DtoAvaliacaoInsercaoAtualizacao : DtoAvaliacaoBase
    {
        /// <summary>
        /// Identificador único do usuário que fez a avaliação.
        /// </summary>
        public string IdDoUsuario { get; set; }

        /// <summary>
        /// Identificador único do produto avaliado.
        /// </summary>
        public string IdDoProduto { get; set; }
    }
}
