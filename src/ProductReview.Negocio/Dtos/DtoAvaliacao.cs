using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Dtos
{
    /// <summary>
    /// Classe DtoAvaliacao que representa uma avaliação feita por um usuário em um produto.
    /// </summary>
    public class DtoAvaliacao : DtoAvaliacaoBase
    {
        /// <summary>
        /// Propriedade DtoUsuario que representa o usuário que fez a avaliação.
        /// </summary>
        public DtoUsuario DtoUsuario { get; set; }

        /// <summary>
        /// Propriedade DtoProduto que representa o produto avaliado.
        /// </summary>
        public DtoProduto DtoProduto { get; set; }

        
    }
}
