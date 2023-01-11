namespace ProductReview.Negocio.Entidades
{
    public class Produto : EntidadePersistente
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
