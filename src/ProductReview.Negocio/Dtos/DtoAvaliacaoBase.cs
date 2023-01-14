using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Dtos
{
    public class DtoAvaliacaoBase : DtoPadrao
    {
        /// <summary>
        /// Propriedade Titulo que representa o título da avaliação.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Propriedade Comentario que representa o comentário escrito na avaliação.
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Propriedade QuantidadeEstrelas que representa a quantidade de estrelas atribuídas na avaliação.
        /// </summary>
        public int QuantidadeEstrelas { get; set; }
    }
}
