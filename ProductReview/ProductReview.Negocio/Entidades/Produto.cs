namespace ProductReview.Negocio.Entidades
{
    public class Produto
    {
        /// <summary>
        /// O identificador do produto.
        /// </summary>
        public Guid Id { get; set; }

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
