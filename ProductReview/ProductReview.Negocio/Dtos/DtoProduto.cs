using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Dtos
{
    public class DtoProduto : DtoPadrao
    {
        /// <summary>
        /// O nome do produto.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// A descrição do produto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// A categoria do produto.
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// O valor unitário do produto.
        /// </summary>
        public decimal ValorUnitario { get; set; }
    }
}
