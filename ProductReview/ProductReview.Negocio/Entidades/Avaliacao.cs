namespace ProductReview.Negocio.Entidades
{
    public class Avaliacao : EntidadePersistente
    {
        /// <summary>
        /// Identificador único do usuário que fez a avaliação.
        /// </summary>
        public Guid IdDoUsuario { get; set; }

        /// <summary>
        /// Identificador único do produto avaliado.
        /// </summary>
        public Guid IdDoProduto { get; set; }

        /// <summary>
        /// Título da avaliação.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Comentário da avaliação.
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Quantidade de estrelas da avaliação.
        /// </summary>
        public int QuantidadeEstrelas { get; set; }
    }
}
